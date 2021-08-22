<template lang="">
    <div class="paging-bar">
        <div class="total-record">
            Tổng số: <strong>{{paging.totalRecord}}</strong> bản ghi
        </div>

        <div>
            <combo-box
                id="cbxPageSize"
                ref="cbxPageSize"
                name="cbxPageSize"
                fieldName="pageSize"
                @itemSelected="onPageSizeChange"
                isDropdown
            />
            <div class="paging-container">
            <button class="paging-btn" id="pagingPrev"
            :value="paging.currentPage - 1"
            :disabled="paging.currentPage <= 1"
            @click="selectPage"
            >
            Trước
            </button>
            <button 
                v-if="!generatePageNumber.includes(1)"
                class="paging-num"
                :class="{'active': paging.currentPage == 1}"
                :value="1"
                @click="selectPage"
            >
                1
            </button>
            <div v-if="!generatePageNumber.includes(1) && !(paging.currentPage == 3)">
                ...
            </div>
            <button 
                class="paging-num"
                v-for="(item,index) in generatePageNumber"
                :key="'page' + index"
                :class="{'active': item == paging.currentPage}"
                :value="item"
                @click="selectPage"
            >
            {{item}}
            </button>
            <div v-if="!generatePageNumber.includes(paging.totalPage) && !(paging.currentPage == paging.totalPage - paging.numberOfButton + 1)">
                ...
            </div>
            <button 
                v-if="!generatePageNumber.includes(paging.totalPage)"
                class="paging-num"
                :class="{'active': paging.totalPage == paging.currentPage}"
                :value="paging.totalPage"
                @click="selectPage"
            >
                {{paging.totalPage}}
            </button>
            <button 
                class="paging-btn" id="pagingNext"
                :value="parseInt(paging.currentPage) + 1"
                :disabled="paging.currentPage >= paging.totalPage"
                @click="selectPage"
            >
            Sau
            </button>
        </div>
      </div>
    </div>
</template>

<script>
/*
 * Component phân trang
 * Created_by: VMHOANG
 */
export default {
  emits: ["paging-update"],

  props: {
    paging: {
      //page hiện tại
      currentPage: {
        type: Number,
        required: true,
      },
      //tổng số trang
      totalPage: {
        type: Number,
      },
      //tổng số bản ghi
      totalRecord: {
        type: Number,
      },
      //kích thước trang
      pageSize: {
        type: Number,
        required: true,
      },
      //Số nút chuyển trang hiển thị
      numberOfButton: {
        type: Number,
        required: true,
      },
    },
  },

  watch: {
    /**
     * Lắng nghe sự kiện thay đổi thông số phân trang
     * CREATED_BY: VMHOANG (25/07/2021)
     */
    paging: {
      immediate: false,
      handler(newValue) {
        this.$refs["cbxPageSize"].selectByValue(`${newValue.pageSize}`);
      },
    },
  },

  computed: {
    /**
     * Số trang hiển thị
     * CREATED_BY: VMHOANG (18/07/2021)
     */
    generatePageNumber() {
      let numberArrays = [];

      //trường hợp chung
      let count = 0;
      for (
        let i = this.paging.currentPage - 1;
        i <= this.paging.totalPage;
        i++
      ) {
        count++;
        if (count > this.paging.numberOfButton) {
          break;
        }
        numberArrays.push(i);
      }

      //trường hợp page = 1
      if (this.paging.currentPage == 1) {
        numberArrays.shift();
        if (numberArrays[numberArrays.length - 1] < this.paging.totalPage) {
          numberArrays.push(numberArrays[numberArrays.length - 1] + 1);
        }
      }

      //trường hợp những page cuối
      if (this.paging.currentPage >= this.paging.totalPage - 1) {
        for (
          let i = this.paging.totalPage - this.paging.currentPage + 2;
          i <= this.paging.numberOfButton - 1;
          i++
        ) {
          if (this.paging.currentPage - i >= 1) {
            numberArrays.unshift(this.paging.currentPage - i);
          }
        }
      }

      return numberArrays;
    },
  },

  methods: {
    /**
     * Handle chọn trang
     * CREATED_BY: VMHOANG (18/07/2021)
     */
    selectPage(event) {
      this.$emit("paging-update", {
        ...this.paging,
        currentPage: event.target.getAttribute("value"),
      });
    },

    /**
     * Handle thông số phân trang thay đổi
     * @param {Object} item {currentPage, totalPage, totalRecord, pageSize, numberOfButton}
     */
    onPageSizeChange(item) {
      if (parseInt(item.value) !== this.paging.pageSize) {
        this.$emit("paging-update", {
          ...this.paging,
          pageSize: parseInt(item.value),
        });
      }
    },
  },
};
</script>
<style scoped>
@import "./Index.css";
</style>