<template>
  <the-modal :open="true" class="m-popup" @modal-close="closePopup" ref="modal">
    <template #content>
      <div class="m-modal-icon-container">
        <div class="m-modal-icon sprite"></div>
      </div>
      <div class="m-modal-text">
        <p>
          <slot></slot>
        </p>
      </div>
    </template>
    <template #footer>
      <base-button
        type="secondary"
        @click="closePopup"
        id="popup-btn-2"
        :tabindex="1"
      >
        {{ $attrs.btn2 }}
      </base-button>

      <div>
        <base-button
          type="secondary"
          @click="cancelPopup"
          id="popup-btn-3"
          :tabindex="2"
        >
          {{ $attrs.btn3 }}
        </base-button>

        <base-button
          type="primary"
          @click="confirmPopup"
          v-if="$attrs.type !== 'info'"
          id="popup-btn-1"
          :tabindex="3"
        >
          {{ $attrs.btn1 }}
        </base-button>
      </div>
    </template>
  </the-modal>
</template>


<script>
/*
 * Component popup
 * Created_by: VMHOANG
 */
export default {
  name: "ThePopup",

  emits: ["close", "cancel", "confirm"],

  mounted() {
     this.$refs.modal.$refs.card.focus()
  },

  methods: {
    /**
     * Đóng popup
     * CREATED_BY: VMHOANG (16/07/2021)
     */
    closePopup() {
      this.$emit("close");
    },

    /**
     * Hủy popup
     * CREATED_BY: VMHOANG (16/07/2021)
     */
    cancelPopup() {
      this.$emit("cancel");
    },

    /**
     * Handle bấm xác nhận
     * CREATED_BY: VMHOANG (16/07/2021)
     */
    confirmPopup() {
      this.$emit("confirm");
    },
  },
};
</script>

<style lang="scss">
/* @import "./Index.css";
 */
.m-popup {
  .m-modal-backdrop {
    // background-color: transparent;
  }

  .m-modal-card {
    width: 444px;
    border-radius: 4px !important;
    box-shadow: none;
  }

  .m-modal-header {
    text-transform: none;
    .m-modal-title {
      text-transform: none !important;
    }
  }

  .m-modal-content {
    width: 100%;
    padding: 32px 32px 0 32px !important;
    align-items: center;
    display: flex !important;
    align-items: flex-start;
    justify-content: flex-start;

    .m-modal-icon-container {
      width: 48px;
      height: 48px;
      display: flex;
      justify-content: center;
      align-items: center;
    }

    .m-modal-text {
      margin-bottom: 32px;
      padding-top: 12px;
      padding-left: 16px;
    }
  }

  .m-modal-footer {
    display: flex;
    justify-content: space-between;
    border-top: 2px solid #b8bcc3 !important;
    padding-bottom: 32px !important;

    & > div {
      display: flex;
      gap: 6px;
    }
  }
}

.m-popup[type="alert"] {
  .m-modal-icon {
    background-position: -752px -462px;
    width: 36px;
    height: 36px;
  }

  .m-modal-footer {
    justify-content: center;

    #popup-btn-2,
    #popup-btn-3 {
      display: none;
    }
  }
}

.m-popup[type="warning"] {
  .m-modal-icon {
    background-position: -598px -463px;
    width: 36px;
    height: 37px;
  }

  .m-modal-footer {
    justify-content: flex-end;
  }

  #popup-btn-2,
  #popup-btn-3 {
    display: none;
  }
}

.m-popup[type="confirm-1"] {
  .m-modal-icon {
    background-position: -832px -462px;
    width: 36px;
    height: 36px;
  }
}

.m-popup[type="confirm-2"] {
  .m-modal-icon {
    background-position: -598px -463px;
    width: 36px;
    height: 37px;
  }

  #popup-btn-3 {
    display: none;
  }
}

.m-popup[type="info"] {
  .m-modal-icon {
    background-position: -672px -462px;
    width: 36px;
    height: 36px;
  }

  .m-modal-footer {
    justify-content: center;

    #popup-btn-2,
    #popup-btn-3 {
      display: none;
    }
  }
}
</style>
