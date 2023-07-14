
<template>
    <div class="card font">
        <div class="card-header align-items-center d-flex">
            <h4 class="card-title mb-0 flex-grow-1">
                {{ $t("t-demand-comment") }}
            </h4>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-xxl-12">

                </div>
                <div class="col-lg-12">
                    <label class="form-label">{{ $t("t-explanation") }} <span class="text-danger">*</span></label>

                    <textarea class="form-control" id="comment" v-if="entityModel" v-model="entityModel.Description" required rows="3"></textarea>
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
export default {
  props:{
    commentId : String,
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
      entityModel: undefined
    };
  },

  components: {
  },

  created() {
    this.getRecord();
  },
  methods: {
    getRecord() {
      let self = this;
      let config = {
        headers: {
          "controllerName": "demandcomment",
        },
      };
      const path = process.env.SERVICE_ADDRESS + "GetMeta";
      appAxios.get(path, config).then((res) => {
        self.entityModel = JSON.parse(String(res.data));
        self.entityModel.UserId = 1017;
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
        "CorporateMethodName": "CommentInsertUpdate",
        "RequestParams": {
          "CommentJson":JSON.stringify(self.entityModel)
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
