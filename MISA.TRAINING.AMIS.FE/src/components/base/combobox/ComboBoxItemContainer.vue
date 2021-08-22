<template>
  <div
    v-show="show"
    class="dropdown-item-container"
    :id="id"
    :class="{ up: up }"
    ref="itemsContainer"
  >
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
      <div class="m-dropdown-item-text">{{ dropdownItem.text }}</div>
    </div>
  </div>
</template>

<script>
/**
 * Dropdown hiện items của combobox
 * Created_by: VMHOANG
 */
export default {
  name: "ComboBoxContainer",
  components: {},

  emits: ["item-click"],

  props: {
    id: {
      type: String,
    },
    //Mảng chứa các items
    dropdownItems: {
      type: Array,
    },
    //Hiện
    show: {
      type: Boolean,
    },
    //Hiện lên trên
    up: {
      type: Boolean,
    },
    //Index của item đã được chọn
    selectedIndex: {
      type: Number,
    },
    //Index của item đang được chọn
    selectingIndex: {
      type: Number,
    },
  },

  watch: {
    /**
     * Theo dõi index đang được chọn
     * CREATED_BY: VMHOANG (17/07/2021)
     */
    selectingIndex() {
      //Set vị trí scroll
      this.$refs.itemsContainer.scrollTop = 48 * this.selectingIndex;
    },
  },

  data() {
    return {
      isShow: false,
    };
  },

  methods: {
    /**
     * Handler click vào 1 item
     * @param {Number} index tên
     * CREATED_BY: VMHOANG (14/07/2021)
     */
    onItemClicked (event, index) {
      this.$emit("item-click", index);
    },
  },
};
</script>

<style scoped>
@import "./ComboBoxItemContainer.css";
</style>