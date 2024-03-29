import { BasicLayout, GridContent } from '@ant-design/pro-layout';
import LayoutSpin from "components/other/LayoutSpin";
import GlobalConfig from 'global.config';
import lodash from 'lodash';
import { action, toJS } from 'mobx';
import { observer } from 'mobx-react';
import * as React from 'react';
import { renderRoutes } from 'react-router-config';
import { Link } from 'react-router-dom';
import Store from 'store/index';
import RightContent from './GlobalHeader/RightContent';
import UserMenu from './GlobalHeader/userMenu';
import TabsPages from './TabsPages';
import SettingDrawer, { ContentWidth } from './SettingDrawer';
import './style.less';
// import { ConfigConsumer } from 'antd/lib/config-provider';
// import {  } from 'antd';
// ConfigConsumer
@observer
export default class App extends React.Component<any> {
    static con
    /**
     *settings 变更 事件
     *
     * @param {*} settings
     * @memberof App
     */
    @action.bound
    onSettingChange(settings) {
        GlobalConfig.settings = settings;
    }
    @action.bound
    changeLang(event) {
        GlobalConfig.language = event.key;
        window['g_locale'] = GlobalConfig.language;
    }
    // 菜单 打开 的 key
    defaultOpenKeys = [];
    // 菜单 选择 的 key
    selectedKeys = [];
    //  获取 
    getDefaultOpenKeys(Menus, Menu, OpenKeys = []) {
        const ParentId = lodash.get(Menu, 'ParentId');
        if (ParentId) {
            OpenKeys.push(ParentId);
            const Parent = lodash.find(Menus, ["Id", ParentId]);
            if (Parent.ParentId) {
                this.getDefaultOpenKeys(Menus, Parent, OpenKeys);
            }
        }
        return OpenKeys
    }
    // 根据 路径获取对应菜单
    getMenu(pathname) {
        const menu = lodash.find(Store.Meun.ParallelMenu, ["path", pathname]);
        this.selectedKeys = [lodash.get(menu, 'Id', '/')]
        return menu;
    }
    UNSAFE_componentWillMount() {
        this.defaultOpenKeys = this.getDefaultOpenKeys(Store.Meun.ParallelMenu, this.getMenu(this.props.location.pathname));
    }
    UNSAFE_componentWillUpdate(nextProps) {
        if (this.props.location.pathname !== nextProps.location.pathname) {
            this.defaultOpenKeys = this.getDefaultOpenKeys(Store.Meun.ParallelMenu, this.getMenu(nextProps.location.pathname));
        }
    }
    componentDidMount() {
    }
    public render() {
        const settings = toJS(GlobalConfig.settings);
        const { language } = GlobalConfig;
        // window['g_locale']='en-US'
        return (
            <>
                <BasicLayout
                    logo={GlobalConfig.default.logo}
                    {...settings}
                    rightContentRender={rightProps => (
                        <RightContent {...rightProps} selectedLang={language} changeLang={this.changeLang} >
                            <UserMenu {...rightProps} {...this.props} />
                        </RightContent>
                    )}
                    menuHeaderRender={(logo, title) => <Link to="/">{logo}{title}</Link>}
                    menuDataRender={() => toJS(Store.Meun.subMenu)}
                    menuItemRender={(menuItemProps, defaultDom) => {
                        if (menuItemProps.isUrl && lodash.startsWith(menuItemProps.path, '/external')) {
                            defaultDom = <Link to={menuItemProps.path}>{lodash.get(defaultDom, 'props.children')}</Link>
                        }
                        return menuItemProps.isUrl ? defaultDom : <Link to={menuItemProps.path}>{defaultDom}</Link>;
                    }}
                    menuProps={{
                        selectedKeys: this.selectedKeys,
                        openKeys: this.defaultOpenKeys,
                        onOpenChange: event => {
                            this.defaultOpenKeys = [...event];
                            this.forceUpdate();
                        }
                    }}
                    footerRender={() => null}
                >
                    {settings.tabsPage && settings.contentWidth !== "Fixed" ? <TabsPages {...this.props} /> : <MainContent {...this.props} contentWidth={settings.contentWidth} />}
                </BasicLayout>
                <SettingDrawer settings={settings} onSettingChange={this.onSettingChange} />
            </>
        );
    }
}
class MainContent extends React.Component<{ contentWidth: ContentWidth, route?: any }> {
    shouldComponentUpdate(nextProps: any, nextState: any, nextContext: any) {
        return !lodash.eq(this.props.contentWidth, nextProps.contentWidth)
    }
    renderRoutes = renderRoutes(this.props.route.routes);
    render() {
        return (
            <GridContent contentWidth={this.props.contentWidth}>
                <React.Suspense fallback={<LayoutSpin />}>
                    {this.renderRoutes}
                </React.Suspense>
            </GridContent>
        );
    }
}
