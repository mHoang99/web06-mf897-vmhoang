<template>
  <table class="base-table" border="0">
    <caption></caption>
    <!-- --------------------------------------HEADER-------------------------------------- -->
    <thead>
      <tr>
        <th
          id="outter-left-cell-header"
          v-if="paddingLeft"
          :style="'left:0; min-width:' + paddingLeft"
          class="sticky-cell-header outer-cell"
        />
        <th
          id="checkbox-all"
          class="sticky-cell-header"
          :style="'left:' + paddingLeft"
        >
          <input type="checkbox" class="" v-model="checkAll" />
        </th>
        <th
          v-for="(item, index) in tableData.columns"
          :key="item.id + index"
          :id="item.id"
          :style="item.style"
          :fieldname="item.fieldname"
          :formattype="item.formattype ? item.formattype : ''"
        >
          <div :class="item.position">
            <span>{{ item.title }}</span>
          </div>
        </th>
        <th
          id="table-option-header"
          key="table-option-header"
          class="option-header sticky-cell-header"
          :style="'right:' + paddingRight"
        >
          <div class="text-align-center">
            <span>Chức năng</span>
          </div>
        </th>
        <th
          id="outter-right-cell-header"
          v-if="paddingRight"
          :style="'right:0; min-width:' + paddingRight"
          class="sticky-cell-header outer-cell"
        />
      </tr>
      <div v-if="paddingLeft" />
    </thead>

    <!-- --------------------------------------BODY-------------------------------------- -->
    <tbody ref="tableBody">
      <tr
        v-for="(record, index) in tableData.data"
        :key="'record' + index"
        :id="'record' + index"
        @dblclick="editClickHandler(index)"
      >
        <td
          :id="'outter-left-cell-' + index"
          :key="'outter-left-cell-' + index"
          v-if="paddingLeft"
          :style="'left:0; min-width:' + paddingLeft"
          class="sticky-cell-body outer-cell"
        />
        <td class="sticky-cell-body" :style="'left:' + paddingLeft">
          <input
            type="checkbox"
            class=""
            :id="'checkbox-' + index"
            :checked="checkAll"
          />
        </td>
        <td
          v-for="(column, idx) in tableData.columns"
          :key="'td' + index + '' + idx"
          :id="'td' + index + '' + idx"
          :style="column.style"
          :title="formatData(record[column.fieldname], column.formattype)"
        >
          <div :class="column.position">
            <span>{{
              formatData(record[column.fieldname], column.formattype)
            }}</span>
          </div>
        </td>
        <td
          :id="'row-option-' + index"
          :key="'row-option-' + index"
          class="row-option sticky-cell-body"
          :style="'right:' + paddingRight"
        >
          <div>
            <div @click="editClickHandler(index)">Sửa</div>
            <div>
              <div
                class="sprite icon-arrow-down-blue"
                @click.prevent.stop="openContextMenu($event, index)"
              ></div>
            </div>
          </div>
        </td>
        <td
          :id="'outter-right-cell-' + index"
          :key="'outter-right-cell-' + index"
          v-if="paddingRight"
          :style="'right:0px; min-width:' + paddingRight"
          class="sticky-cell-body outer-cell"
        />
      </tr>
    </tbody>
  </table>

  <!-- Không có dữ liệu -->
  <div class="no-data" v-if="tableData.data.length <= 0">
    <div class="no-data-img"></div>
    <div class="no-data-text">Không có dữ liệu</div>
  </div>

  <!-- context menu -->
  <teleport to="#app">
    <context-menu id="contextMenuTableRow" :status="contextMenu">
      <div @click="cloneClickHandler">Nhân bản</div>
      <div @click="deleteClickHandler">Xóa</div>
      <div @click="developingToast">Ngừng sử dụng</div>
    </context-menu>
  </teleport>
</template>

<script>
import ContextMenu from "../ContextMenu.vue";
import Formater from "../../../common/format";
import notificationMixin from "../../../mixins/notification.mixin";

/*
 * Component bảng tái sử dụng 
 * Created_by: VMHOANG
 */
export default {
  name: "BaseTable",

  emits: ["edit-btn-click", "delete-btn-click", "clone-btn-click"],

  mixins: [notificationMixin],

  components: { ContextMenu },

  props: {
    tableData: {
      data: {
        type: Array,
      },
      columns: {
        type: Array,
      },
    },
    paddingLeft: {
      type: String,
    },

    paddingRight: {
      type: String,
    },
  },

  data() {
    return {
      // hàng đang được chọn
      selectedRow: -1,
      // trạng thái của context menu
      contextMenu: {
        isShow: false,
        positionX: "0px",
        positionY: "0px",
      },
      //Chọn hết checkbox
      checkAll: false,

      checkingRow: [],
    };
  },

  created() {
    //add event listeners vào document
    document.addEventListener("click", this.documentClick);
    document.addEventListener("contextmenu", this.documentClick);
  },

  watch: {
    reloading() {
      if (this.reloading === true) {
        this.loadData();
      }
    },
  },

  methods: {
    /**
     * hàm format dữ liệu
     * CREATED_BY: VMHOANG (14/07/2021)
     */
    formatData(str, formatType) {
      if (formatType) {
        switch (formatType) {
          case "ddmmyyyy":
            str = Formater.formatDate(str);
            break;
          case "money":
            str = Formater.formatMoney(str);
            break;
          case "gender":
            str = Formater.formatGender(parseInt(str));
            break;
          default:
            break;
        }
      }
      return str;
    },

    /**
     * handler khi bấm sửa
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    editClickHandler(index) {
      this.$emit("edit-btn-click", true, "edit", this.tableData.data[index]);
      this.closeContextMenu();
    },

    /**
     * handler khi bấm delete trong context menu
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    deleteClickHandler() {
      this.$emit(
        "delete-btn-click",
        true,
        this.tableData.data[this.selectedRow]
      );
      this.closeContextMenu();
    },

    /**
     * Hàm nhân bản context menu
     * CREATED_BY: VMHOANG (16/08/2021)
     */
    cloneClickHandler() {
      this.$emit(
        "clone-btn-click",
        true,
        "clone",
        this.tableData.data[this.selectedRow]
      );
      this.closeContextMenu();
    },

    /**
     * Hàm đóng context menu
     * CREATED_BY: VMHOANG (16/08/2021)
     */
    closeContextMenu() {
      this.contextMenu = {
        isShow: false,
        positionX: 0 + "px",
        positionY: 0 + "px",
      };
    },

    /**
     * Hàm mở context menu
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    openContextMenu(event, index) {
      //   console.log(event.target.getBoundingClientRect());
      this.contextMenu = {
        isShow: true,
        positionX: event.target.getBoundingClientRect().x + "px",
        positionY: event.target.getBoundingClientRect().y + "px",
      };
      this.selectedRow = index;
      event.target.closest("tr").classList.add("active");
    },

    /**
     * Handler bấm vào document
     * CREATED_BY: VMHOANG (15/07/2021)
     */
    documentClick(e) {
      let els = this.$refs.tableBody.children;
      let target = e.target;
      els.forEach((el) => {
        if (el !== target && !el.contains(target)) {
          el.classList.remove("active");
        }
      });
    },
  },

  unmounted() {
    // xóa event listeners khỏi document
    document.removeEventListener("click", this.documentClick);
    document.removeEventListener("contextmenu", this.documentClick);
  },
};
</script>
<style scoped>
@import "./Index.css";
</style>