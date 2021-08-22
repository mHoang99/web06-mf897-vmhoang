<template>
  <div
    v-show="show"
    class="dropdown-item-container department-dropdown-item-container"
    :id="id"
    :class="{ up: up }"
    ref="itemsContainer"
  >
    <div class="m-dropdown-item m-dropdown-item-header">
      <div class="m-dropdown-item-text dropdown-col-1">Mã đơn vị</div>
      <div class="m-dropdown-item-text dropdown-col-2">Tên đơn vị</div>
    </div>
    <div class="m-dropdown-item-body">
      <div
        v-for="(dropdownItem, index) in dropdownItems"
        class="m-dropdown-item"
        :class="{
          'dropdown-item-picked': index === selectedIndex,
          'dropdown-item-selecting': index === selectingIndex,
        }"
        :id="id + 'Item' + index"
        :key="index"
        @click="onItemClicked($event, index)"
      >
        <div class="m-dropdown-item-text dropdown-col-1">
          {{ dropdownItem.data?.DepartmentCode }}
        </div>
        <div class="m-dropdown-item-text dropdown-col-2">
          {{ dropdownItem.data?.DepartmentName ?? dropdownItem.text }}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import ComboBoxItemContainer from "../ComboBoxItemContainer.vue";

/**
 * Danh sách hiển thị của combobox - department
 * Created_by: VMHOANG
 */
export default {
  extends: ComboBoxItemContainer,
};
</script>

<style lang="scss" scoped>
.department-dropdown-item-container {
  padding: 0 !important;
  .dropdown-col-1 {
    flex-basis: 20%;
  }
  .dropdown-col-2 {
    padding-left: 6px;
    flex: 1;
  }
  .m-dropdown-item-header {
    cursor: default;
    font-weight: 700;
    &,
    &:hover {
      background-color: #f4f5f8;
    }
  }

  .m-dropdown-item-body {
    padding: 2px 1px;
  }

  .dropdown-item-selecting,
  .dropdown-item-picked {
    background-color: #ebedf0 !important;
  }

  .dropdown-item-picked .m-dropdown-item-text {
    color: #35bf22 !important;
    font-weight: 700;
  }

  .m-dropdown-item-text {
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
  }
}
</style> 