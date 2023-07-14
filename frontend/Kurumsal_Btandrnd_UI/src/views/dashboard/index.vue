<script>
import { defineAsyncComponent } from "vue";

const Layout = defineAsyncComponent(() => import("kurumsalbody/Layout"));
const PageHeader = defineAsyncComponent(() => import("kurumsalbody/PageHeader"));

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
    };
  },
  methods: {
  },
};
</script>

<template>
  <Layout>
    <PageHeader :title="title" :items="items" />
   <p class="font">Bt Dashboard</p>
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