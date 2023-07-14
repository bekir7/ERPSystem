<script>
export default {
  components: {},
  props: {
    title: {
      type: String,
      default: "",
    },
    items: {
      type: Array,
      default: () => {
        return [];
      },
    },
  },
};
</script>

<template>
  <!-- start page title -->
  <div class="row font">
    <div class="col-12">
      <div
        class="page-title-box d-sm-flex align-items-center justify-content-between"
      >
        <h4 class="mb-sm-0">{{ title }}</h4>

        <div class="page-title-right">
          <ol class="breadcrumb m-0">
            <li
              class="breadcrumb-item"
              v-for="(item, index) in items"
              :key="index"
              :class="{ active: item[0] }"
            >
              <a href="javascript: void(0);">{{ item.text }}</a>
            </li>
          </ol>
        </div>
      </div>
    </div>
  </div>
  <!-- end page title -->
</template>

<style>
@import url("https://fonts.googleapis.com/css2?family=Nunito:wght@300;400;500;600;700&display=swap");

@font-face {
  font-family: "Nunito";
  src: url("https://fonts.googleapis.com/css2?family=Nunito:wght@300;400;500;600;700&display=swap");
}
.font {
  font-family: "Nunito", sans-serif;
}
</style>
