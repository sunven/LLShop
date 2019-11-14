import { ColDef, ColGroupDef } from 'ag-grid-community';
import { AgGrid } from 'components/dataView';
import React from 'react';
import Store from '../store';
import Action from './action';
// 列配置
const columnDefs: (ColDef | ColGroupDef)[] = [

    {
        field: "Name",
        headerName: "分类名称"
    },

    {
        field: "Description",
        headerName: "分类描述"
    },

    {
        field: "Seq",
        headerName: "排序"
    },

    {
        field: "FileAttachmentId",
        headerName: "附件",
        cellRenderer: "columnsRenderDownload" 
    }

]
/**
 * 表格
 */
export default class extends React.Component<any, any> {
    render() {
        return <AgGrid
            Store={Store} 
            columnDefs={columnDefs} 
            rowAction={Action.rowAction} 
			rowHeight={30}
        />
    }
}
