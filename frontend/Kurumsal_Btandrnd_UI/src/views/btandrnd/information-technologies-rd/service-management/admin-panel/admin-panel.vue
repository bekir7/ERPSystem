<script>
import { defineAsyncComponent } from "vue";

const Layout = defineAsyncComponent(() => import("kurumsalbody/Layout"));
const PageHeader = defineAsyncComponent(() => import("kurumsalbody/PageHeader"));
import axios from "axios";
import appConfig from "@/../app.config";
import DataTable from 'datatables.net-bs5';
import $ from 'jquery'; 

export default {
    page: {
    title: "Admin Paneli",
    meta: [
      {
        name: "description",
        content: appConfig.description,
      },
    ],
  },
  components: {
    Layout,
    PageHeader,
  },
  data() {
    return {
        title: this.$t("t-admin-panel"),
      items: [
        {
            text: this.$t("t-service-management"),
          href: "/",
        },
        {
            text: this.$t("t-admin-panel"),
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
   <p class="font">Admin Paneli</p>
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