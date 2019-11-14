import { BindAll } from 'lodash-decorators';
import DataSource from 'store/dataSource';
@BindAll()
export class Store extends DataSource {
    constructor() {
        super({
            // IdKey: "ID", 默认 ID
            // Target: "/api", 默认 /api
            Apis: {
                search: {
                    url: "/category/search",
                    method: "post"
                },
                details: {
                    // 支持 嵌套 参数 /user/{ID}/{AAA}/{BBB}
                    url: "/category/{ID}",
                    method: "get"
                },
                insert: {
                    url: "/category/add",
                    method: "post"
                },
                update: {
                    url: "/category/edit",
                    method: "put"
                },
                delete: {
                    url: "/category/BatchDelete",
                    method: "post"
                },
                import: {
                    url: "/category/import",
                    method: "post"
                },
                export: {
                    url: "/category/ExportExcel",
                    method: "post"
                },
                exportIds: {
                    url: "/category/ExportExcelByIds",
                    method: "post"
                },
                template: {
                    url: "/category/GetExcelTemplate",
                    method: "get"
                }
            }
        });
    }
}
export default new Store();