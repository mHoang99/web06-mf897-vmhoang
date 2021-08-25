import { GENDER_NAME } from "../resources/const";
import GENDER from "../resources/enums/gender";

/**
 * Class chứa các hàm format
 * CREATED_BY: VMHOANG (15/07/2021)
 */
class Formater {
    /**
     * Format dữ liệu ngày sang ngày tháng năm dưới dạng dd/MM/yyyy cho input date
     * @param {any} date Bất kì kiểu dữ liệu nào
     * CreatedBy: VMHOANG (06/07/2021)
     */
    formatDate(date) {
        if (!date) return "";

        date = new Date(date);

        if (Number.isNaN(date.getTime())) {
            return "";
        }

        let day = date.getDate();
        day = day < 10 ? "0" + day : day;

        let month = date.getMonth() + 1;
        month = month < 10 ? "0" + month : month;

        let year = date.getFullYear();

        return day + `/` + month + "/" + year;
    }

    /**
     * Format dữ liệu ngày sang ngày tháng năm dưới dạng yyyy-MM-dd cho input date
     * @param {any} date Bất kì kiểu dữ liệu nào
     * CreatedBy: VMHOANG (06/07/2021)
     */
    formatDateForInput(date) {
        if (!date) return "";

        date = new Date(date);

        if (Number.isNaN(date.getTime())) {
            return "";
        }

        let day = date.getDate();
        day = day < 10 ? '0' + day : day;

        let month = date.getMonth() + 1;
        month = month < 10 ? '0' + month : month;

        let year = date.getFullYear();

        return year + `-` + month + `-` + day;
    }

    /**
     * Format 1 số sang dạng tiền có chấm ngăn cách
     * @param {Number} money  
     * @returns string giá trị số có chấm ngăn cách
     */
    formatMoney(money) {
        if (money) {
            return money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
        }
        return "";
    }

    /**
     * Chuyển giới tính từ số sang chữ
     * @param {Any} genderIndex 
     * @returns giá trị chữ của giới tinh
     */
    formatGender(genderIndex) {
        switch (genderIndex) {
            case GENDER.MALE:
                return GENDER_NAME.MALE
            case GENDER.FEMALE:
                return GENDER_NAME.FEMALE
            case GENDER.OTHER:
                return GENDER_NAME.OTHER
            default:
                return null;
        }
    }
}

export default new Formater()