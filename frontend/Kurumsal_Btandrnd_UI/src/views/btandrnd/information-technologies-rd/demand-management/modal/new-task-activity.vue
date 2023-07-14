
<template>
    <div class="card font">
        <div class="card-header align-items-center d-flex">
            <h4 class="card-title mb-0 flex-grow-1">
                Proje Aktivitesi
            </h4>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-xxl-12">

                </div>
                <div class="col-lg-12">
                    <label class="form-label">{{ $t("t-explanation") }} <span class="text-danger">*</span></label>
                    <textarea class="form-control"  v-if="entityModel" v-model="entityModel.Description" required rows="3"></textarea>
                </div>
              <div class="col-lg-4">
                <label class="form-label">Bitiş Tarihi <span class="text-danger">*</span></label>
                <input type="date" class="form-control"  v-if="entityModel" v-model="entityModel.EndDate">
              </div>
              <div class="col-lg-3">
              <label class="form-label">
                {{ $t("t-task-status") }}</label>
              <div class="hstack gap-2 flex-wrap">
                <input type="radio" class="btn-check" name="activitystatus" id="activitystatus1" v-if="entityModel"
                       v-model="entityModel.StatusId" value="A">
                <label class="btn btn-outline-success" for="activitystatus1">Açık</label>
                <input type="radio" class="btn-check" name="activitystatus" v-if="entityModel"
                       v-model="entityModel.StatusId" id="activitystatus2" value="K">
                <label class="btn btn-outline-success" for="activitystatus2">Kapalı</label>

              </div>
              </div>
              <div class="col-lg-4">
                <label for="valueInput" class="form-label">Kişi</label>
                <Multiselect :placeholder="$t('t-choose')" :close-on-select="true" :searchable="true"
                             :create-option="false" v-if="entityModel" v-model="entityModel.AuthorizeUserId" :options="this.users" />
              </div>
            </div>
        </div>
      <div class="card-footer">
        <div class="row">
          <div class="col-lg-12 text-end">
            <button type="button" class="btn btn-success  text-right" @click="save" data-bs-dismiss="modal">
              <i class="ri-close-line align-bottom me-1"></i> {{ $t("t-save") }}</button>
          </div>
        </div>
      </div>
    </div>
</template>
<script>

import { appAxios } from "kurumsalcontainer/appAxios";
import Multiselect from "@vueform/multiselect";
import "@vueform/multiselect/themes/default.css";
export default {
  props:{
    modalDataJson: Object
  },
  mixins:["notificationMixin"],
  data() {
    return {
      demandCategories: [],
      demandProcess: null,
      digitalService: [],
      digitalSuitability: [],
      scope: null,
      cargoNumber: null,
      departments: [],
      mailAdress: [],
      result: true,
      entityModel: undefined,
      users:[]
    };
  },

  components: {
    Multiselect
  },

  async created() {
    let self = this;
    this.getRecord();
    await self.getUsers().then((res) => {
      self.users = res;
    });
  },
  methods: {
    getRecord() {
      let self = this;
      let config = {
        headers: {
          "controllerName": "demandprojectactivity",
        },
      };
      const path = process.env.SERVICE_ADDRESS + "GetMeta";
      appAxios.get(path, config).then((res) => {
        self.entityModel = JSON.parse(String(res.data));
        self.entityModel.UserId = 1016;
        self.entityModel.Id = 0;
        self.entityModel.DemandId = Number(self.$route.query.id);

      }).then(()=>{
        if (self.modalDataJson!=null) {
          self.entityModel = self.modalDataJson
        }
      }).catch((error) => console.log(error));
    },
    save() {
      let self = this;
      let config = {
        headers: {
          "Content-Type": "application/json"
        },
      };
      let reqdata = {
        "CorporateTypeName": "OperationDemand",
        "CorporateMethodName": "ActivityInsertUpdate",
        "RequestParams": {
          "ActivityJson":JSON.stringify(self.entityModel)
        }
      };
      appAxios.post(
          process.env.SERVICE_ADDRESS + "api/ProcessOperations/ProcessOperationPost",
          reqdata,
          config

      )
          // eslint-disable-next-line no-unused-vars
          .then(function (response) {
            self.successmsg();
            setTimeout(()=>{
              location.reload()
            },1000)
          })
          .catch(function (error) {
            console.log(error);
            console.error("Kayıt başarısız", error);
          });
    }
  },
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
