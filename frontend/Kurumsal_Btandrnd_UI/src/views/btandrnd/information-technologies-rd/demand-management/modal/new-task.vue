
<template>
    <div class="card font">
        <div class="card-header align-items-center d-flex">
            <h4 class="card-title mb-0 flex-grow-1">
                {{ $t("t-new-task") }}
            </h4>
        </div>
        <div class="card-body">
            <div class="row g-3">

                <div class="col-xxl-12">
                    <label class="form-label">
                        {{ $t("t-task-type") }}</label>
                    <div class="hstack gap-2 flex-wrap">
                        <input type="radio" class="btn-check" name="tasktype" v-if="modalEntityModel"
                            v-model="modalEntityModel.TaskTypeId" id="tasktype1" value="A">
                        <label class="btn btn-outline-success" for="tasktype1">Analiz</label>
                        <input type="radio" class="btn-check" name="tasktype" v-if="modalEntityModel"
                            v-model="modalEntityModel.TaskTypeId" id="tasktype2" value="G">
                        <label class="btn btn-outline-success" for="tasktype2">Geliştirme</label>
                        <input type="radio" class="btn-check" name="tasktype" v-if="modalEntityModel"
                            v-model="modalEntityModel.TaskTypeId" id="tasktype3" value="T">
                        <label class="btn btn-outline-success" for="tasktype3">Test</label>
                        <input type="radio" class="btn-check" name="tasktype" v-if="modalEntityModel"
                            v-model="modalEntityModel.TaskTypeId" id="tasktype4" value="C">
                        <label class="btn btn-outline-success" for="tasktype4">Canlı</label>
                    </div>
                </div>
                <div class="col-xxl-12">
                    <label class="form-label">
                        {{ $t("t-task-status") }}</label>
                    <div class="hstack gap-2 flex-wrap">
                        <input type="radio" class="btn-check" name="taskstatus" id="taskstatus1" v-if="modalEntityModel"
                            v-model="modalEntityModel.TaskStatusId" value="A">
                        <label class="btn btn-outline-success" for="taskstatus1">Açık</label>
                        <input type="radio" class="btn-check" name="taskstatus" v-if="modalEntityModel"
                            v-model="modalEntityModel.TaskStatusId" id="taskstatus2" value="K">
                        <label class="btn btn-outline-success" for="taskstatus2">Kapalı</label>

                    </div>
                </div>
                <div class="col-xxl-4">
                    <label class="form-label">{{ $t("t-task-requested-start-date") }}</label>
                    <input type="date" v-if="modalEntityModel" v-model="modalEntityModel.TaskRequestedStartDate"
                        class="form-control" />
                </div>
                <div class="col-xxl-4">
                    <label class="form-label">{{ $t("t-task-requested-end-date") }}</label>
                    <input type="date" v-if="modalEntityModel" v-model="modalEntityModel.TaskRequestedEndDate"
                        class="form-control" />
                </div>
                <div class="col-xxl-4">
                    <label class="form-label">{{ $t("t-task-real-end-date") }}</label>
                    <input type="date" v-if="modalEntityModel" v-model="modalEntityModel.TaskRealEndDate"
                        class="form-control" />
                </div>
                <div class="col-lg-12">
                    <label class="form-label">{{ $t("t-explanation") }} <span class="text-danger">*</span></label>
                    <textarea class="form-control" v-if="modalEntityModel" v-model="modalEntityModel.Note"
                        id="newArrivedDocumentExplanation" required rows="3" placeholder="Açıklama"></textarea>
                </div>
                <div class="col-lg-">
                    <div class="input-group">
                        <input type="file" class="form-control" id="inputGroupFile03"
                            aria-describedby="inputGroupFileAddon03" aria-label="Upload">
                    </div>
                </div>
            </div>
        </div>
        <div class="card-footer">
            <div class="row">
                <div class="col-lg-12 text-end">

                    <button v-if="modalEntityModel && modalEntityModel.Id == 0"  type="button" class="btn btn-success  text-right" @click="save" data-bs-dismiss="modal">
                        <i class="ri-close-line align-bottom me-1"></i> {{ $t("t-save") }}</button>

                  <button v-if="modalEntityModel && modalEntityModel.Id > 0"  type="button" class="btn btn-primary  text-right" @click="save">
                    <i class="ri-pencil-line align-bottom me-1"></i> {{ $t("t-update") }}</button>
                </div>
            </div>
        </div>

    </div>
</template>
<script>
import "@vueform/multiselect/themes/default.css";
import { appAxios } from "kurumsalcontainer/appAxios";
export default {

    data() {
        return {
            modalEntityModel: undefined
        };
    },
    mixins:["notificationMixin"],

      props:{
        demandDetailId : String,
        modalDataJson: Object
      },
    methods: {
        getRecord() {
            let self = this;

              let config = {
                headers: {
                  "controllerName": "demanddetail",
                },
              };
              const path = process.env.SERVICE_ADDRESS + "GetMeta";
              appAxios.get(path, config).then((res) => {
                self.modalEntityModel = JSON.parse(String(res.data));
                self.modalEntityModel.UserId = 1017;
                self.modalEntityModel.Id = 0;
                self.modalEntityModel.TaskStatusId = 'A';
                self.modalEntityModel.DemandId = Number(self.$route.query.id);
              }).then(()=>{
                if (self.modalDataJson!=null) {
                  self.modalEntityModel = self.modalDataJson
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
                "CorporateMethodName": "TaskInsertUpdate",
                "RequestParams": {
                  "strjson":JSON.stringify(self.modalEntityModel)
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
                  },1500)
                })
                .catch(function (error) {
                    console.log(error);
                    console.error("Kayıt başarısız", error);
                });
        }
    },
    created() {
        let self = this;
        console.log(self.$route.query);
        self.getRecord();
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
