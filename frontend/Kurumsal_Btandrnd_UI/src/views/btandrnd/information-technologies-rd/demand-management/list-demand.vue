<template>

<div class="card font">
  <div class="card-body">
    <div class="row">
      <div class="offset-lg-7 col-lg-2 text-end">


        <Multiselect :placeholder="'Durum'" :close-on-select="true" :searchable="true"
                     :create-option="true"  :options="this.demandStatus" @clear="filterDemandStatusClear()" @select="filterDemandStatus($event)"/>
      </div>
      <div class="col-lg-3 text-end">
        <Multiselect :placeholder="'Proje Yöneticisi'" :close-on-select="true" :searchable="true"
                     :create-option="true"  :options="this.users" @clear="filterProjectManagerClear()" @select="filterProjectManager($event)"/>
      </div>
    </div>

  </div>
</div>
    <div class="card font">
      <div class="card-body">

        <div class="table-responsive table-card mb-1">
          <table class="table align-middle" id="demand-master-table2">
            <thead class="table-light text-muted"></thead>
          </table>
        </div>
      </div>
    </div>

</template>
<style>

</style>

<script>
import Layout from "../../../Layout.vue";
import PageHeader from "../../../PageHeader";
import $ from "jquery";
import appConfig from "@/../app.config";
import Multiselect from "@vueform/multiselect";
import "@vueform/multiselect/themes/default.css";
import demandStatus from "../../../../static-data/demand-status.json";

export default {
  page: {
    title: "Talep Yönetimi",
    meta: [
      {
        name: "description",
        content: appConfig.description,
      },
    ],
  },
  target: {
    target: "",
  },
  mixins: ["pageComponentsMixin","getItemMixin"],
  data() {
    return {
      filterArray: [],
      filterIsApply: false,
      users:[],
      tables: undefined,
      entityModel: undefined,
      dataTable: undefined,
      columns: undefined,
      title: this.$t("t-demand-management"),
      pageName: "demand-management",
      transactionStatus: "new-record",
      demandStatus: demandStatus,
      items: [
        {
          text: this.$t("t-demand-management"),
          href: "/",
        },
        {
          text: this.$t("t-demand-management"),
          active: true,
        },
      ],
      load: true,
    };
  },
  components: {
    Multiselect
  },
  computed: {},

  mounted() {
    let self = this
    setTimeout(()=>{
      self.getList();
    },100)

  },
  async created() {
    let self = this;
    await self.getUsers().then((res) => {
      self.users = res;
    });
  },
  methods: {
    filterProjectManagerClear(){
      let self = this;
      self.filterIsApply = false;
      self.dataTable.clear().destroy();
      self.createTable();
    },
    filterDemandStatusClear(){
      let self = this;
      self.filterIsApply = false;
      self.dataTable.clear().destroy();
      self.createTable();
    },
    filterProjectManager(e){
      console.log(e)
      let self = this;
      self.filterIsApply = true;
      $.grep(self.filterArray, function (v) {
        if (v && v.index === 13) {
          self.filterArray.splice($.inArray(v, self.filterArray), 1);
        }
      });
      if (e >0) {
        self.filterArray.push({ index: 13, value: '==' + e });
      }

      self.dataTable.clear().destroy();
      self.createTable();
    },
    filterDemandStatus(e){
      console.log(e)
      let self = this;
      self.filterIsApply = true;
      $.grep(self.filterArray, function (v) {
        if (v && v.index === 14) {
          self.filterArray.splice($.inArray(v, self.filterArray), 1);
        }
      });
      if (e >0) {
        self.filterArray.push({ index: 14, value: '==' + e });
      }
      self.dataTable.clear().destroy();
      self.createTable();
    },
    createTable() {
      let self = this;
      self.dataTable = self.createDataTables($("#demand-master-table2"), "DemandMasterListOdata", 0, self.columns,this.filterIsApply ? this.filterArray : null,'and','<f<t>lip>', false,'single', 50);
    },
    dblclick(dataId) {
      let self = this;
      self.$router.push({name: 'new-demand', query: {id: dataId}});

    },
    getList() {
      let self = this;
      self.columns = [
        {mData: "Id", sType: "numeric", sTitle: "Id"},

        {mData: "ProjectName", sType: "string", sTitle: "Proje Adı",
          render:function (data,type,row){
            if (data != null){
              return data
            }
            else {
              return '-'
            }
          }},
        {mData: "ProjectStartDate", sType: "date", sTitle: "Proje Başlangıç Tarihi",
          render:function (data,type,row){
            if (data != null){
              return data
            }
            else {
              return '-'
            }
          }},
        {mData: "ProjectEndDate", sType: "date", sTitle: "Proje Bitiş Tarihi",
          render:function (data,type,row){
            if (data != null){
              return data
            }
            else {
              return '-'
            }
          }},
        {mData: "ScopeName", sType: "string", sTitle: "Kapsam",
          render:function (data,type,row){
            if (data != null){
              return data
            }
            else {
              return '-'
            }
          }
        },
        {mData: "StrategicSuitability", sType: "string", sTitle: "Stratejik Uygunluk",
          render:function (data,type,row){
            if (data != null){
              return data
            }
            else {
              return '-'
            }
          }},
        {mData: "BtDigitalService", sType: "string", sTitle: "BT Dijital Servis",
          render:function (data,type,row){
            if (data != null){
              return data
            }
            else {
              return '-'
            }
          }},
        {mData: "OperationalBenefit", sType: "string", sTitle: "Operasyonel Fayda",
          render:function (data,type,row){
            if (data != null){
              return data
            }
            else {
              return '-'
            }
          }},
        {mData: "ApplicationName", sType: "string", sTitle: "Uygulama",
          render:function (data,type,row){
            if (data != null){
              return data
            }
            else {
              return '-'
            }
          }},
        {mData: "StatusName", sType: "string", sTitle: "Durum",
          render:function (data,type,row){
            if (data != null){
              return data
            }
            else {
              return '-'
            }
          }},
        {mData: "ProcessName", sType: "string", sTitle: "Süreç",
          render:function (data,type,row){
            if (data != null){
              return data
            }
            else {
              return '-'
            }
          }},
        {mData: "DepartmentNameArr", sType: "string", sTitle: "Departman",
          render:function (data,type,row){
            if (data != null){
              return data
            }
            else {
              return '-'
            }
          }
          },
        {mData: "UserName", sType: "string", sTitle: "Proje Yöneticisi",
          render:function (data,type,row){
            if (data != null){
              return data
            }
            else {
              return '-'
            }
          }
        },
        {mData: "UserId", sType: "numeric", sTitle: "UserId",
          render:function (data,type,row){
            if (data != null){
              return data
            }
            else {
              return 0
            }
          },
          visible:false
        },
        {mData: "StatusId", sType: "numeric", sTitle: "StatusId",
          render:function (data,type,row){
            if (data != null){
              return data
            }
            else {
              return 0
            }
          },
          visible:false
        }

      ];
      self.createTable();

      $("#demand-master-table2 tbody").on("dblclick", "tr", function () {
        var data = self.dataTable.row(this).data();
        self.dblclick(data.Id);
      });

    },
  },
};
</script>