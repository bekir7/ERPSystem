<script>
 import { defineAsyncComponent } from "vue";
 const Layout = defineAsyncComponent(() => import("kurumsalbody/Layout"));

export default {
  components: {
    Layout,
  },
};
</script>

<template>
  <Layout>  
    <slot />    
  </Layout>
</template>

