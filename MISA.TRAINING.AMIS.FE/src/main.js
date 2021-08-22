import { createApp } from 'vue'
import router from './router/index'
import store from './store/index'
import App from './App.vue'
import '@fortawesome/fontawesome-free/css/all.css'
import '@fortawesome/fontawesome-free/js/all.js'
import axiosConfig from "./services/axiosConfig";
import 'v-tooltip/dist/v-tooltip.css'
import VTooltip from 'v-tooltip'
import BaseButton from './components/base/button/Index.vue'
import ComboBox from './components/base/combobox/Index.vue'
import BaseInput from './components/base/input/Index.vue'
import DateInput from './components/base/input/DateInput.vue'
import TheLabel from './components/base/label/Index.vue'
import TheModal from './components/base/modal/Index.vue'
import ThePopup from './components/base/popup/Index.vue'
import TheLoading from './components/base/UI/TheLoading.vue'
require("./common/prototype");

//config axios
axiosConfig()

const app = createApp(App)

//Vue Router
app.use(router);

//VueX
app.use(store);

//Component
app.component('base-button', BaseButton);

app.component('combo-box', ComboBox);

app.component('base-input', BaseInput);

app.component('date-input', DateInput);

app.component('the-label', TheLabel);

app.component('the-popup', ThePopup);

app.component('the-loading', TheLoading);

app.component('the-modal', TheModal);

//V-tooltip
app.use(VTooltip, {
    themes: {
        'info-tooltip': {
            $extend: 'tooltip',
        },
        'alert-tooltip': {
            $extend: 'tooltip',
        },
    }
});

//mount
app.mount('#app')
