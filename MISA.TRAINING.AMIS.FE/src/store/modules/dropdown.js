import dropdownService from '../../services/dropdown.service';
import Utils from '../../common/utils';

/**
 * Module cho việc xử lý dữ liệu của dropdown
 * CREATED_BY: VMHOANG (14/08/2021)
 */
const dropdownModule = {
    state() {
        return {
            //Danh sách dữ liệu của dropdown
            dictionaries: {
                pageSize: [
                    {
                        value: "10",
                        text: "10 bản ghi trên 1 trang"
                    },
                    {
                        value: "20",
                        text: "20 bản ghi trên 1 trang"
                    },
                    {
                        value: "30",
                        text: "30 bản ghi trên 1 trang"
                    },
                    {
                        value: "50",
                        text: "50 bản ghi trên 1 trang"
                    },
                    {
                        value: "100",
                        text: "100 bản ghi trên 1 trang"
                    }
                ],
            },

            //Danh sách sẵn sàng
            available: {
                pageSize: true
            }
        }
    },

    mutations: {
        /**
         * Thêm dữ liệu dropdown mới
         * @param {object} payload data đầu vào
         * CREATED_BY: VMHOANG (14/08/2021)
         */
        addToDictionary(state, payload) {
            let fieldName = Utils.camelize(payload.fieldName);
            state.dictionaries[fieldName] = dropdownService.castToDict(fieldName, payload.data);
            state.dictionaries = { ...state.dictionaries };
        },

        /**
         * Chuyển trạng thái sẵn sàng
         * @param {String} fieldName 
         * CREATED_BY: VMHOANG (14/08/2021)
         */
        makeAvailable(state, fieldName) {
            fieldName = Utils.camelize(fieldName);
            state.available[fieldName] = true;
        },

        /**
         * Chuyển trạng thái chưa sẵn sàng
         * @param {String} fieldName 
         * CREATED_BY: VMHOANG (14/08/2021)
         */
        makeNotAvailable(state, fieldName) {
            fieldName = Utils.camelize(fieldName);
            state.available[fieldName] = false;
        }
    },

    actions: {
        /**
         * Lấy dữ liệu từ API cho dropdown bằng tên
         * @param {String} fieldName 
         * CREATED_BY: VMHOANG (14/08/2021)
         */
        async fetchDropdownData(context, fieldName) {
            try {
                fieldName = Utils.camelize(fieldName);
                if (context.state.available[fieldName] !== true) {
                    context.commit('makeAvailable', fieldName);
                    let res = await dropdownService.getByFieldName(fieldName)
                    context.commit(
                        'addToDictionary',
                        {
                            fieldName: fieldName,
                            data: res?.data ?? []
                        }
                    );
                }
            } catch (e) {
                context.commit('makeNotAvailable', fieldName);
                console.log(e);
            }

            fieldName = Utils.camelize(fieldName);
            if (context.state.available[fieldName] !== true) {
                context.commit('makeAvailable', fieldName);

            }
        }
    },

    getters: {
        /**
         * Lấy ra dữ liệu của 1 dropdown
         * @returns Danh sách item
         * CREATED_BY: VMHOANG (14/08/2021)
         */ 
        dropdownDictionary: (state) => (fieldName) => {
            fieldName = Utils.camelize(fieldName);
            return state.dictionaries[fieldName];
        }
    }
}

export default dropdownModule