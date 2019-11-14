import { Input, Switch, Icon, Select, Upload, message, Modal,InputNumber } from 'antd';
import { WtmCascader, WtmCheckbox, WtmDatePicker, WtmEditor, WtmRadio, WtmSelect, WtmTransfer, WtmUploadImg, WtmUpload } from 'components/form';
import { FormItem } from 'components/dataView';
import * as React from 'react';
import lodash from 'lodash';
import Regular from 'utils/Regular';
import Request from 'utils/Request';

/**
 * label  标识
 * rules   校验规则，参考下方文档  https://ant.design/components/form-cn/#components-form-demo-validate-other
 * formItem  表单组件
 */
export default {
    /**
     * 表单模型 
     * @param props 
     */
    editModels(props?): WTM.FormItem {
        return {
            /** 分类名称 */
            "Entity.Name":{
                label: "分类名称",
                rules: [{ "required": true, "message": "分类名称不能为空" }],
                formItem: <Input placeholder="请输入 分类名称" />
            },
            /** 分类描述 */
            "Entity.Description":{
                label: "分类描述",
                rules: [],
                formItem: <Input placeholder="请输入 分类描述" />
            },
            /** 排序 */
            "Entity.Seq":{
                label: "排序",
                rules: [{ "required": true, "message": "排序不能为空" }],
                formItem: <InputNumber placeholder="请输入 排序" />
            },
            /** 附件 */
            "Entity.FileAttachmentId":{
                label: "附件",
                rules: [{ "required": true, "message": "附件不能为空" }],
                formItem: <WtmUploadImg />
            }

        }
    },
    /**
     * 搜索 模型 
     * @param props 
     */
    searchModels(props?): WTM.FormItem {
        return {

        }
    },
    /**
     * 渲染 模型
     */
    renderModels(props?) {
        return lodash.map(props.models, (value, key) => {
            return <FormItem {...props} fieId={key} key={key} />
        })
    },
    
    getValue(props: WTM.FormProps, fieId, defaultvalue = undefined) {
        var rv = lodash.toString(props.form.getFieldValue(fieId) || lodash.get(props.defaultValues, fieId));
        if (rv == "") {
            rv = lodash.toString(defaultvalue);
        }
        return rv;
    }
}