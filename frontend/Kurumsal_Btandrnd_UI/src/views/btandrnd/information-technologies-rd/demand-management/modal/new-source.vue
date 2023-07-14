<template>
  <div class="card font">
    <div class="card-header align-items-center d-flex">
      <h4 class="card-title mb-0 flex-grow-1">
        {{ $t("t-new-source") }}
      </h4>
    </div>

    <div class="card-body">
      <div class="row g-3">
        <div class="card">
          <div class="card-body">
            <div class="col-xxl-4">
              <label class="form-label">
                {{ $t("t-source-type") }}</label>
              <div class="hstack gap-2 flex-wrap">
                <input type="radio" class="btn-check" v-model="sourceType" name="sourcetype" id="sourcetype1" value="I"
                >
                <label class="btn btn-outline-success" for="sourcetype1">İç Kaynak</label>
                <input type="radio" class="btn-check" v-model="sourceType" name="sourcetype" id="sourcetype2" value="D"
                >
                <label class="btn btn-outline-success" for="sourcetype2">Dış Kaynak</label>
              </div>
            </div>
          </div>
        </div>
        <div class="card" style="background-color: #f8f8f8!important;margin: 0px!important;"
             v-if="sourceType != null">
          <div class="card-body">
            <div class="row g-3">
              <div class="col-xxl-12" v-show="sourceType == 'I'">
                <label for="valueInput" class="form-label">{{ $t("t-source-name") }}</label>
                <Multiselect :placeholder="$t('t-choose')" :close-on-select="true" :searchable="true"
                             :create-option="false" v-if="entityModel" v-model="entityModel.SourceUserId" :options="this.users" required/>
              </div>
              <div class="col-xxl-6" v-show="sourceType == 'D'">
                <label for="valueInput" class="form-label">{{ $t("t-source-company-name") }}</label>
                <Multiselect
                    v-if="entityModel" v-model="entityModel.CompanyId"
                    placeholder="<BAKIMDA>"
                    :filter-results="false"
                    :min-chars="1"
                    :resolve-on-load="false"
                    :delay="0"
                    :searchable="true"
                    :options="this.companyMaster"
                />
<!--                <Multiselect :placeholder="$t('t-choose')" :close-on-select="true" :searchable="true"-->
<!--                             :create-option="false"  v-if="entityModel" v-model="entityModel.CompanyId" :options="this.companyMaster" required/>-->
              </div>
              <div class="col-xxl-6">
                <label class="form-label">{{ $t("t-source-estimated-efor-day") }}</label>
                <input type="number" v-if="entityModel" v-model="entityModel.EstimatedEffortDay" @blur="calcEstimated($event)" class="form-control"/>
              </div>
              <div class="col-xxl-6">
                <label class="form-label">{{ $t("t-source-real-efor-day") }}</label>
                <input type="number" v-if="entityModel" v-model="entityModel.RealEffortDay"  @blur="calcReal($event)" class="form-control"/>
              </div>
              <div class="col-xxl-6">
                <label class="form-label">{{ $t("t-source-estimated-daily-cost") }}</label>
                <input type="number" v-if="entityModel" v-model="entityModel.EstimatedDailyCost" class="form-control" />
              </div>
              <div class="col-xxl-6">
                <label class="form-label">{{ $t("t-source-real-daily-cost") }}</label>
                <input type="number" v-if="entityModel" v-model="entityModel.RealDailyCost" class="form-control"/>
              </div>
              <div class="col-xxl-6">
                <label class="form-label">{{ $t("t-source-estimated-sum-cost") }}</label>
                <input type="number" v-if="entityModel" v-model="entityModel.EstimatedSumCost" class="form-control" />
              </div>
              <div class="col-xxl-6">
                <label class="form-label">{{ $t("t-source-real-sum-cost") }}</label>
                <input type="number" v-if="entityModel" v-model="entityModel.RealSumCost" class="form-control"/>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="card-footer">
      <div class="row">
        <div class="col-lg-12 text-end">
          <button  v-if="entityModel && entityModel.Id == 0" type="button" class="btn btn-success  text-right" data-bs-dismiss="modal" @click="save">
            <i class="ri-close-line align-bottom me-1"></i> {{ $t("t-save") }}
          </button>

          <button v-if="entityModel && entityModel.Id > 0"  type="button" class="btn btn-primary  text-right" @click="save">
            <i class="ri-pencil-line align-bottom me-1"></i> {{ $t("t-update") }}</button>

          <button v-if="entityModel && entityModel.Id > 0"  type="button" class="btn btn-danger  text-right" @click="deleteSource">
            <i class="ri-pencil-line align-bottom me-1"></i> {{ $t("t-delete") }}</button>

        </div>
      </div>
    </div>

  </div>
</template>
<script>
import Multiselect from "@vueform/multiselect";
import "@vueform/multiselect/themes/default.css";
import {appAxios} from "kurumsalcontainer/appAxios";
import Layout from "@/views/Layout.vue";
import PageHeader from "@/views/PageHeader.vue";
import NewTask from "@/views/btandrnd/information-technologies-rd/demand-management/modal/new-task.vue";
import NewTaskComment from "@/views/btandrnd/information-technologies-rd/demand-management/modal/new-task-comment.vue";

export default {

  data() {
    return {
      sourceType: null,
      entityModel: undefined,
      users:[]
    };
  },
  components: {
    Multiselect,
  },

  mixins: ["notificationMixin,getItemMixin"],
  async created() {
    let self = this;
    self.getRecord();
    await self.getUsers().then((res) => {
      self.users = res;
    });
  },
  methods: {
    calcEstimated(event){
      let self = this;
      self.entityModel.EstimatedSumCost = event.target.value * self.entityModel.EstimatedDailyCost;
    },
    calcReal(event){
      let self = this;
      self.entityModel.RealSumCost = event.target.value * self.entityModel.RealDailyCost;
    },
    deleteSource(){
      let self = this;
      let config = {
        headers: {
          "Content-Type": "application/json"
        },
      };
      let reqdata = {
        "CorporateTypeName": "OperationDemand",
        "CorporateMethodName": "DeleteSource",
        "RequestParams": {
          "sourceId": self.entityModel.Id.toString()
        }
      };
      appAxios.post(
          process.env.SERVICE_ADDRESS + "api/ProcessOperations/ProcessOperationPost",
          reqdata,
          config
      )
          // eslint-disable-next-line no-unused-vars
          .then(function (response) {
            self.successmsg()
          })
          .catch(function (error) {
            console.log(error);
            console.error("Kayıt başarısız", error);
          });
    },
    getRecord() {
      let self = this;
      //self.getCompanyMaster();
      let config = {
        headers: {
          "controllerName": "demandsource",
        },
      };
      const path = process.env.SERVICE_ADDRESS + "GetMeta";
      appAxios.get(path, config).then((res) => {
        self.entityModel = JSON.parse(String(res.data));
        self.entityModel.UserId = 991;
        self.entityModel.Id = 0;
        self.entityModel.EstimatedDailyCost =5000;
        self.entityModel.RealDailyCost =5000;
        self.entityModel.RealSumCost =0;
        self.entityModel.EstimatedSumCost =0;
        self.entityModel.DemandDetailId = Number(self.demandDetailId)
        self.entityModel.DemandId = Number(self.$route.query.id);
      }).then(() => {
        if (self.modalDataJson != null) {
          self.entityModel = self.modalDataJson
          self.sourceType = self.entityModel.Type
        }
      }).catch((error) => console.log(error));


    },

    save() {
      let self = this;
      self.entityModel.DemandId =Number(self.$route.query.id);
      self.entityModel.DemandDetailId = Number(self.demandDetailId);
      self.entityModel.Type = self.sourceType;
      let config = {
        headers: {
          "Content-Type": "application/json"
        },
      };
      let reqdata = {
        "CorporateTypeName": "OperationDemand",
        "CorporateMethodName": "SourceInsertUpdate",
        "RequestParams": {
          "sourceModelJson": JSON.stringify(self.entityModel)
        }
      };
      appAxios.post(
          process.env.SERVICE_ADDRESS + "api/ProcessOperations/ProcessOperationPost",
          reqdata,
          config
      )
          // eslint-disable-next-line no-unused-vars
          .then(function (response) {
            self.successmsg()
          })
          .catch(function (error) {
            console.log(error);
            console.error("Kayıt başarısız", error);
          });
    }
  },

  props: {
    sourceId: String,
    modalDataJson: Object,
    companyMaster: Array,
    demandDetailId:String
  }
};
</script>
<style>
@font-face {
  font-family: "Nunito";
  src: url("https://fonts.googleapis.com/css2?family=Nunito:wght@300;400;500;600;700&display=swap");
}

.font {
  font-family: "Nunito", sans-serif;
}
</style>
