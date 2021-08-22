import Utils from "./utils"

var ValidatorMixin = {
    methods: {
        /**
         * Hàm dùng để validate email
         * @param {String} email
         * @returns true: hợp lệ | false: không hợp lệ
         * CreatedBy: VMHOANG (04/07/2021)
         */
        testEmail(email) {
            var emailRegex = /^([a-zA-Z0-9_.+-])+@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            return emailRegex.test(email);
        },

        /**
         * Hàm dùng để validate tên tiếng việt
         * @param {String} name tên
         * @returns true: hợp lệ | false: không hợp lệ
         * CreatedBy: VMHOANG (09/07/2021)
         */
        testName(name) {
            name = Utils.removeVietnameseTones(name);
            return this.testAlphabetOnly(name);
        },
        /**
         * Hàm dùng để validate chỉ số
         * @param {String} string
         * @returns true: hợp lệ | false: không hợp lệ
         * CreatedBy: VMHOANG (04/07/2021)
         */
        testNumberOnly(string) {
            var numRegex = /^\d+$/;
            return numRegex.test(string);
        },

        /**
         * Hàm dùng để validate chỉ chữ và dấu cách
         * @param {String} string
         * @returns true: hợp lệ | false: không hợp lệ
         * CreatedBy: VMHOANG (04/07/2021)
         */
        testAlphabetOnly(string) {
            var alphaRegex = /^[a-zA-Z\s]*$/;
            return alphaRegex.test(string);
        },

        /**
         * Hàm dùng để validate chỉ số và chữ
         * @param {String} string
         * @returns true: hợp lệ | false: không hợp lệ
         * CreatedBy: VMHOANG (04/07/2021)
         */
        testNumberAndAlphabetOnly(string) {
            var regex = /^([a-zA-Z0-9_.+-])+@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            return regex.test(string);
        },

        /**
         * Hàm dùng để validate số điện thoại
         * @param {String} string 
         * @returns true: hợp lệ | false: không hợp lệ
         * CreatedBy: VMHOANG (09/07/2021)
         */
        testPhoneNumber(string) {
            var regex = /^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s./0-9]*$/g;
            return regex.test(string);
        },

        
        /**
         * Hàm dùng để validate ngày dưới dạng yyyy-mm-dd
         * @param {String} string 
         * @returns true: hợp lệ | false: không hợp lệ
         * CreatedBy: VMHOANG (20/08/2021)
         */
        testInputDateFormat(string) {
            var regex = /([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))/
            return regex.test(string);
        },

        /**
         * Hàm dùng để kiểm tra phím có phải số hay không
         * @param {any} event
         * @returns true: hợp lệ | false: không hợp lệ
         * CreatedBy: VMHOANG (04/07/2021)
         */
        isNumberKey(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if ((charCode > 31 && (charCode < 48 || charCode > 57)) && !this.testNumberOnly(event.value))
                return false;
            return true;
        }
    }
}

export default ValidatorMixin;