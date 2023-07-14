<script>

import Layout from "../../layouts/main.vue";
import PageHeader from "../../components/page-header.vue";

export default {
  components: {
    Layout,
    PageHeader,
  },
  data() {
    return {
      title: "Dashboard",
      items: [
        {
          text: "Dashboards",
          href: "/",
        },
        {
          text: "Dashboard",
          active: true,
        },
      ],
      date: null,
      config: {
        mode: "range",
      },
   
    };
  },
  methods: {
  
  },
};
</script>

<template>
  <Layout>
    <PageHeader :title="title" :items="items" />

  </Layout>
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
