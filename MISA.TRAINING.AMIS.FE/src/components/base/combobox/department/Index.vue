<template>
  <div class="m-dropdown" :id="id" ref="combobox">
    <combo-box-input
      :id="id + 'Input'"
      :open="open"
      :value="inputValue"
      :itemValue="outputValue"
      :itemValid="itemValid"
      v-bind="$attrs"
      :displayName="displayName"
      ref="input"
      @self-valid-changed="onSelfValidChanged"
      @self-required-valid-changed="onSelfRequiredValidChanged"
      @input="onInputChange"
      @change="onInputChange"
      @blur="onInputBlur"
      @toggle-dropdown="toggleDropdown"
      @keydown.down="moveDown"
      @keydown.up="moveUp"
      @keydown.tab="onTabOut"
      @keydown.enter="onItemSelect(selectingItemIndex)"
    />
    <department-combo-box-item-container
      ref="container"
      :show="open"
      :id="id + 'Container'"
      :up="showUp"
      :dropdownItems="dropdownItems"
      :selectedIndex="selectedItemIndex"
      :selectingIndex="selectingItemIndex"
      @item-click="onItemSelect"
    />
  </div>
</template>

<script>
import ComboBox from "../Index.vue";
import ComboBoxInput from "../ComboBoxInput.vue";
import DepartmentComboBoxItemContainer from "./ComboBoxItemContainer.vue"

/**
 * combobox cho department
 * Created_by: VMHOANG
 */
export default {
  name: "DepartmentComboBox",
  extends: ComboBox,
  components: {
    ComboBoxInput,
    DepartmentComboBoxItemContainer,
  },
};
</script>

