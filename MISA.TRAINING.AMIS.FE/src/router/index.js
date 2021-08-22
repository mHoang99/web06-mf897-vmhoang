import { createRouter, createWebHistory } from 'vue-router'
import TheEmployee from '../views/employee/Index.vue'
import InDeveloping from '../views/InDeveloping.vue'

/**
 * Khởi tạo router cho application
 * CREATEDBY: VMHOANG (20/07/2021)
 */
const router = createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: '/employee',
            component: TheEmployee,
            meta: {
                title: "Nhân viên | Danh mục | Công ty Misa"
            }
        },
        {
            path: '/inDevelopment',
            component: InDeveloping,
            meta: {
                title: "AMIS | Đang phát triển"
            }
        },
        {
            path: '/',
            component: InDeveloping,
        },


    ],
    linkActiveClass: "active"
})

router.beforeEach((to, _from, next) => {
    if (to.meta && to.meta.title) {
        document.title = to.meta.title;
    }
    next();
});

export default router;