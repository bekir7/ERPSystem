<script>
 import { defineAsyncComponent } from "vue";
 const PageHeader = defineAsyncComponent(() =>  import("kurumsalbody/PageHeader"));

export default {
  components: {
    PageHeader,
  },
  props: {
    items: Array,
    title: String,
  }
};
</script>

<template>
   <PageHeader :title="title" :items="items" />
</template>

