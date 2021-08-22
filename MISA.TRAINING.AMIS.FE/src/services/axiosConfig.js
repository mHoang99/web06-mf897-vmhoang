import axios from "axios";

/**
 * Hàm config axios
 * CREATED_BY: VMHOANG (16/07/2021) 
 */
const applyConfig = () => {
    axios.defaults.baseURL = "https://localhost:44355/api";
    axios.defaults.headers.post["Content-Type"] = "application/json";
    axios.defaults.headers.post["Access-Control-Allow-Origin"] = "*";
}

export default applyConfig;