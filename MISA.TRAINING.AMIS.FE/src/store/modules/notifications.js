import { v4 as uuidv4 } from 'uuid';

const notiModule = {
    state() {
        return {
            notifications: [
                // {
                //     id: String,
                //     type: String,
                //     duration: Number,
                //     msg: String
                // },
            ]
        }
    },

    mutations: {
        /**
         * Hàm thêm thông báo vào array
         * @param {*} state 
         * @param {*} payload {id, type, duration, msg}
         * CREATEDBY: VMHOANG (21/07/2021)
         */
        addNoti(state, payload) {
            state.notifications = [payload, ...state.notifications]
        },


        /**
         * Hàm xóa thông báo khỏi array
         * @param {*} state 
         * @param {*} notiId id của notification
         * CREATEDBY: VMHOANG (21/07/2021)
         */
        removeNoti(state, notiId) {
            let newNoties = state.notifications.filter((value) => {
                return value.id != notiId
            })

            state.notifications = [...newNoties];
        }
    },

    actions: {
        /**
         * Actions cho việc thêm thông báo vào array
         * @param {*} context 
         * @param {*} payload {id, type, duration, msg}
         */
        addNoti(context, payload) {
            payload = {
                ...payload,
                id: uuidv4(),
            }
            context.commit('addNoti', payload)
            
            //Chờ xóa
            setTimeout(() => {
                context.commit('removeNoti', payload.id)
            }, payload.duration);
        }
    },

    getters: {
        /**
         * Getters lấy toàn bộ list thông báo
         * @param {*} state 
         * @returns list tất cả notifications
         */
        notiList: (state) => {
            return state.notifications
        }
    }
}

export default notiModule