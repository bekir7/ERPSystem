<template>

    <div class="card font">
      <div class="card-header align-items-center d-flex">
        <h4 class="card-title mb-0 flex-grow-1">
          {{ $t("t-new-demand") }}
        </h4>
      </div>
      <b-modal id="newTask" size="lg" style='font-family: "Nunito", sans-serif;' hide-header hide-footer @hide="closeTaskModal">
        <NewTask v-if="showTask" :demandDetailId="this.demandDetailId" :modalDataJson="this.modalEntityJson"></NewTask>
      </b-modal>
      <b-modal id="newTaskComment" size="lg" style='font-family: "Nunito", sans-serif;' hide-header hide-footer @hide="closeCommentModal">
        <NewTaskComment v-if="showComment" :commentId="this.commentId" :modalDataJson="this.modalEntityCommentJson"></NewTaskComment>
      </b-modal>
      <b-modal id="newSource" size="lg" style='font-family: "Nunito", sans-serif;' hide-header hide-footer @hide="closeSourceModal">
        <NewSource v-if="showSource" :demandDetailId="this.demandDetailId" :sourceId="this.sourceId" :modalDataJson="this.modalEntitySourceJson" :companyMaster="this.companyMaster"></NewSource>
      </b-modal>
      <b-modal id="newTaskActivity" size="lg" style='font-family: "Nunito", sans-serif;' hide-header hide-footer @hide="closeActivityModal">
        <new-task-activity v-if="showActivity"  :modalDataJson="this.modalEntityActivityJson"></new-task-activity>
      </b-modal>
      <div class="card-body">
        <div class="row g-3">
          <div class="col-xxl-12">
            <div class="row">
              <div class="col-xxl-3 mb-3">
                <label for="readonlyInput" class="form-label">
                  Proje Adı</label>
                <input type="text" class="form-control" name="demand-project-name" placeholder="Proje Adı" v-if="entityModel" v-model="entityModel.Name"/>
              </div>
              <div class="col-xxl-2 mb-3">
                <label for="readonlyInput" class="form-label">
                  Proje Başlangıç Tarihi</label>
                <input type="date" class="form-control" name="demand-project-start-date" v-if="entityModel" v-model="entityModel.StartDate"/>
              </div>
              <div class="col-xxl-2 mb-3">
                <label for="readonlyInput" class="form-label">
                  Proje Bitiş Tarihi</label>
                <input type="date" class="form-control" name="demand-project-end-date" v-if="entityModel" v-model="entityModel.EndDate"/>
              </div>
              <div class="col-xxl-5 mb-3">
                <label class="form-label">
                  {{ $t("t-department") }}
                  <span class="text-danger">*</span></label>
                <Multiselect :placeholder="$t('t-choose')"
                             style="height: 39px"
                             v-if="entityModel"
                             v-model="entityModel.DepartmentId"
                             :close-on-select="true"
                             :searchable="true"
                             :create-option="false"
                             :options="departments"
                             required
                             mode="tags"

                />
              </div>
              <div class="col-xxl-2">
                <div>
                  <label for="readonlyInput" class="form-label">
                    {{ $t("t-demand-scope") }}</label>
                  <div class="hstack gap-2 flex-wrap">
                    <input type="radio" class="btn-check" name="demand-scope" id="s1" v-if="entityModel"
                           v-model="entityModel.Scope" value="I">
                    <label class="btn btn-outline-success" for="s1">İç Müşteri</label>

                    <input type="radio" class="btn-check" name="demand-scope" id="s2" v-if="entityModel"
                           v-model="entityModel.Scope" value="D">
                    <label class="btn btn-outline-success" for="s2">Dış Müşteri</label>
                  </div>
                </div>
              </div>
              <div class="col-xxl-3">
                <label class="form-label form-label-sm">
                  {{ $t("t-strategic-suitability") }}
                  <span class="text-danger">*</span>
                </label>
                <div class="hstack gap-2 flex-wrap">
                  <input type="checkbox" class="btn-check" id="su1" v-if="entityModel"
                         v-model="entityModel.StrategicSuitability" value="Daha Dijital">
                  <label class="btn btn-outline-primary" for="su1">Daha Dijital</label>
                  <input type="checkbox" class="btn-check" id="su2" value="Daha Global"
                         v-if="entityModel" v-model="entityModel.StrategicSuitability">
                  <label class="btn btn-outline-primary" for="su2">Daha Global</label>
                  <input type="checkbox" class="btn-check" id="su3" value="Daha Sorumlu"
                         v-if="entityModel" v-model="entityModel.StrategicSuitability">
                  <label class="btn btn-outline-primary" for="su3">Daha Sorumlu</label>
                </div>
              </div>
              <div class="col-xxl-6">
                <label class="form-label form-label-sm">
                  {{ $t("t-bt-digital-service") }}
                  <span class="text-danger">*</span>
                </label>
                <div class="hstack gap-2 flex-wrap">
                  <input type="checkbox" class="btn-check" id="bds1" value="Entegrasyon"
                         v-if="entityModel" v-model="entityModel.BtDigitalService">
                  <label class="btn btn-outline-primary" for="bds1">Entegrasyon</label>
                  <input type="checkbox" class="btn-check" id="bds2" value="E-Doküman"
                         v-if="entityModel" v-model="entityModel.BtDigitalService">
                  <label class="btn btn-outline-primary" for="bds2">E-Doküman</label>
                  <input type="checkbox" class="btn-check" id="bds3" value="İzlenebilirlik"
                         v-if="entityModel" v-model="entityModel.BtDigitalService">
                  <label class="btn btn-outline-primary" for="bds3">İzlenebilirlik</label>
                  <input type="checkbox" class="btn-check" id="bds4" value="Raporlar"
                         v-if="entityModel" v-model="entityModel.BtDigitalService">
                  <label class="btn btn-outline-primary" for="bds4">Raporlar</label>
                  <input type="checkbox" class="btn-check" id="bds5" value="Fiziksel Altyapı"
                         v-if="entityModel" v-model="entityModel.BtDigitalService">
                  <label class="btn btn-outline-primary" for="bds5">Fiziksel Altyapı</label>
                </div>
              </div>

            </div>
          </div>


          <div class="col-xxl-5">
            <div>
              <label class="form-label">
                {{ $t("t-demand-category") }}
                <span class="text-danger">*</span></label>
              <div class="hstack gap-2 flex-wrap">
                <input type="radio" class="btn-check" name="tk" id="tk1" value="YasalZorunluluk"
                       v-if="entityModel" v-model="entityModel.CategoryId">
                <label class="btn btn-outline-success" for="tk1">Yasal Zorunluluk</label>

                <input type="radio" class="btn-check" name="tk" id="tk2" value="KurumZorunluluğu"
                       v-if="entityModel" v-model="entityModel.CategoryId">
                <label class="btn btn-outline-success" for="tk2">Kurum Zorunluluğu</label>

                <input type="radio" class="btn-check" name="tk" id="tk3" value="İyileştirme"
                       v-if="entityModel" v-model="entityModel.CategoryId">
                <label class="btn btn-outline-success" for="tk3">İyileştirme</label>

                <input type="radio" class="btn-check" name="tk" id="tk4" value="YeniSüreç"
                       v-if="entityModel" v-model="entityModel.CategoryId">
                <label class="btn btn-outline-success" for="tk4">Yeni Süreç</label>

                <input type="radio" class="btn-check" name="tk" id="tk5" value="YeniMüşteri"
                       v-if="entityModel" v-model="entityModel.CategoryId">
                <label class="btn btn-outline-success" for="tk5">Yeni Müşteri</label>
              </div>
            </div>

          </div>
          <div class="col-xxl-2">
            <div><label class="form-label">
              Talebi Gerçekleştirme Süreci
              <span class="text-danger">*</span>
            </label></div>


            <div class="hstack gap-2 flex-wrap">
              <input type="radio" class="btn-check" name="tgs" id="tgs1" value="P"
                     v-if="entityModel" v-model="entityModel.ProcessId">
              <label class="btn btn-outline-danger" for="tgs1">Proje</label>

              <input type="radio" class="btn-check" name="tgs" id="tgs2" value="D"
                     v-if="entityModel" v-model="entityModel.ProcessId">
              <label class="btn btn-outline-danger" for="tgs2">Değişiklik</label>

              <input type="radio" class="btn-check" name="tgs" id="tgs3" value="A"
                     v-if="entityModel" v-model="entityModel.ProcessId">
              <label class="btn btn-outline-danger" for="tgs3">Ar-Ge</label>
            </div>
          </div>
          <div class="col-xxl-2">
            <div>
              <label class="form-label form-label-sm">
                {{ $t("t-application") }}
                <span class="text-danger">*</span>
              </label>
              <Multiselect :placeholder="$t('t-choose')" style="height: 40px" :close-on-select="true"
                           :searchable="true" :create-option="false" required :options="applications" v-if="entityModel" v-model="entityModel.ApplicationId"/>
            </div>
          </div>
          <div class="col-xxl-3">
            <div>
              <label class="form-label form-label-sm">
                Proje Yöneticisi
                <span class="text-danger">*</span>
              </label>
              <Multiselect :placeholder="$t('t-choose')" :close-on-select="true" :searchable="true"
                           :create-option="false" required :options="this.users" v-if="entityModel" v-model="entityModel.AuthorizeUserId"/>
            </div>
          </div>
          <div class="col-lg-12">
            <label class="form-label">{{ $t("t-explanation") }} <span class="text-danger">*</span></label>

            <textarea v-if="entityModel" v-model="entityModel.OperationalBenefit" class="form-control"
                      id="newArrivedDocumentExplanation" required rows="3" v-on:keyup="countdown"
                      placeholder="Lütfen, talebiniz ile ilgili olarak operasyon ve finansal faydayı detaylı ve sayısal değerler olacak şekilde belirtiniz.&#10;Açıklamanızın yeterli olmadığı durumunda talebiniz iptal edilecektir.&#10;Dijital Dönüşüm Kurulu"></textarea>
          </div>


          <div class="col-xxl-3">
            <div>
              <label class="form-label form-label-sm">
                Talep Durumu
                <span class="text-danger">*</span>
              </label>
              <Multiselect :placeholder="$t('t-choose')" :close-on-select="true" :searchable="true"
                           :create-option="false" required :options="this.demandStatus" v-if="entityModel" v-model="entityModel.StatusId"/>
            </div>
          </div>
          <doc-manager :mdTypeId="96" v-show="this.$route.query.id>0"></doc-manager>
          <div class="card">
            <div class="card-body">

              <ul class="nav nav-pills nav-customs nav-danger mb-3" role="tablist">
                <li class="nav-item">
                  <a class="nav-link active" data-bs-toggle="tab" href="#border-demand-detail"
                     role="tab">Kilometre Taşları</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" data-bs-toggle="tab" href="#border-demand-comment" role="tab">
                    {{
                      $t("t-demand-comment")
                    }}</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" data-bs-toggle="tab" href="#border-demand-sources" role="tab">{{
                      $t("t-sources")
                    }}</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" data-bs-toggle="tab" href="#border-demand-activity" role="tab">
                      Proje Aktivitesi
                    </a>
                </li>
              </ul><!-- Tab panes -->
              <div class="tab-content text-muted">
                <div class="tab-pane active" id="border-demand-detail" role="tabpanel">
                  <div class="d-flex">

                    <div class="flex-grow-1 ms-2">
                      <button v-if="$route.query.id >0" @click="newTaskOpenModal" data-bs-toggle="modal" data-bs-target="#newTask"
                              type="button" title="Görev Ekle"
                              class="btn btn-success btn-sm">
                        <i class="ri-add-circle-line"></i>
                      </button>
                      <table id="border-demand-detail-table"
                             class="table table-bordered dt-responsive nowrap table-striped align-middle"
                             style="width:100%">
                        <thead>

                        </thead>
                      </table>
                    </div>
                  </div>
                </div>
                <div class="tab-pane" id="border-demand-comment" role="tabpanel">
                  <div class="d-flex">

                    <div class="flex-grow-1 ms-2">
                      <button v-if="$route.query.id >0" @click="newTaskCommentOpenModal" data-bs-toggle="modal" data-bs-target="#newTaskComment"
                              type="button" title="Durum Ekle"
                              class="btn btn-success btn-sm">
                        <i class="ri-add-circle-line"></i>
                      </button>
                      <table id="border-demand-comment-table"
                             class="table table-hover nowrap"
                             style="width:100%">
                        <thead>
                        </thead>
                      </table>
                    </div>
                  </div>
                </div>
                <div class="tab-pane" id="border-demand-sources" role="tabpanel">
                  <div class="d-flex">

                    <div class="flex-grow-1 ms-2">
                      <table id="border-demand-source-table"
                             class="table table-bordered dt-responsive nowrap table-striped align-middle"
                             style="width:100%">
                        <thead>
                        </thead>
                      </table>
                    </div>
                  </div>
                </div>
                <div class="tab-pane" id="border-demand-activity" role="tabpanel">
                  <div class="d-flex">

                    <div class="flex-grow-1 ms-2">
                      <button v-if="$route.query.id >0" @click="newTaskActivityOpenModal" data-bs-toggle="modal" data-bs-target="#newTaskActivity"
                              type="button" title="Aktivite Ekle"
                              class="btn btn-success btn-sm">
                        <i class="ri-add-circle-line"></i>
                      </button>
                      <table id="border-demand-activity-table"
                             class="table table-bordered dt-responsive nowrap table-striped align-middle"
                             style="width:100%">
                        <thead>
                        </thead>
                      </table>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div class="row">
            <div class="col-lg-12">
              <edit-tool-bar :enableSave="true" :enableDelete="true" :parentModel="entityModel" :parentController="'Demand'"></edit-tool-bar>
            </div>
          </div>

        </div>
      </div>

    </div>
</template>
<script>
import Multiselect from "@vueform/multiselect";
import "@vueform/multiselect/themes/default.css";
import NewTask from "./modal/new-task.vue";
import NewSource from "./modal/new-source.vue";
import NewTaskComment from "./modal/new-task-comment.vue";
import demandStatus from "../../../../static-data/demand-status.json";
import {appAxios} from "kurumsalcontainer/appAxios";
import editToolBar from "kurumsalcontainer/editToolBar";
import $ from "jquery";
import NewTaskActivity from "@/views/btandrnd/information-technologies-rd/demand-management/modal/new-task-activity.vue";
import docManager from "kurumsalcontainer/docManager";
import moment from "moment";
export default {
  mixins: ['getItemMixin'],
  data() {
    return {
      users: [],
      showTask: false,
      showComment: false,
      showSource: false,
      showActivity: false,
      maxCount: 500,
      remainingCount: 500,
      hasError: false,
      message: '',
      modal: null,
      demandStatus: demandStatus,
      items: [
        {
          text: this.$t("t-demand-management"),
          href: "/",
        },
        {
          text: this.$t("t-new-demand"),
          active: true,
        },
      ],
      demandCategories: [],
      demandProcess: null,
      digitalService: [],
      digitalSuitability: [],
      scope: null,
      title: this.$t("t-demand-management"),
      applications: [],
      departments: [],
      result: true,
      formFileMultipleDocumentSelection: null,
      entityModel: undefined,
      reqData: {},
      columnsDemandDetail: undefined,
      columnsDemandSource: undefined,
      columnsDemandComment: undefined,
      columnsDemandActivity: undefined,
      dataTableDemandDetail: undefined,
      dataTableDemandSource: undefined,
      dataTableDemandComment: undefined,
      dataTableDemandActivity: undefined,
      demandDetailId: null,
      demandId: null,
      commentId: null,
      sourceId: null,
      activityId: null,
      modalEntityJson: null,
      modalEntityCommentJson: null,
      modalEntityActivityJson: null,
      modalEntitySourceJson: null,
      companyMaster: [],
      rowNum: null,
      dataFiles: null
    };
  },

  components: {
    NewTaskActivity,
    Multiselect,
    NewTask,
    NewSource,
    NewTaskComment,
    editToolBar,
    docManager
  },
  mounted() {
    let self = this

    setTimeout(() => {

      if (self.$route.query.id >0) {
        self.getListDemandDetail();
        self.getListDemandSource();
        self.getListDemandComment();
        self.getListDemandActivity();
      }
    }, 100);

  },

  methods: {
    uploadFile() {
      this.dataFiles = this.$refs.formFileMultipleDocumentSelection.files[0];
    },
    submitFile() {
      let self = this;
      const formData = new FormData();
      formData.append('RefId', self.$route.query.id);
      formData.append('UserId', 1016);
      formData.append('DeviceType', 1);
      formData.append('MdTypeId', 95);
      formData.append('formFileMultipleDocumentSelection', this.dataFiles);
      console.log(formData)
      let url = process.env.SERVICE_ADDRESS + "api/Document/DocUpload";
      appAxios.post(url, formData, {
        headers: {
          'Content-Type': 'multipart/form-data'
        }
      }).then(function (response) {
        self.$nextTick(() => {
          console.log(response)
        });
      })
          .catch(function () {
          });
    },
    deleteTask(id) {
      let self = this;
      let config = {
        headers: {
          "Content-Type": "application/json"
        },
      };
      let reqdata = {
        "CorporateTypeName": "OperationDemand",
        "CorporateMethodName": "DeleteTask",
        "RequestParams": {
          "sourceId": id
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
    deleteSource(id) {
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
          "sourceId": id
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
    deleteComment(id) {
      let self = this;
      let config = {
        headers: {
          "Content-Type": "application/json"
        },
      };
      let reqdata = {
        "CorporateTypeName": "OperationDemand",
        "CorporateMethodName": "DeleteComment",
        "RequestParams": {
          "sourceId": id
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
    deleteActivity(id) {
      let self = this;
      let config = {
        headers: {
          "Content-Type": "application/json"
        },
      };
      let reqdata = {
        "CorporateTypeName": "OperationDemand",
        "CorporateMethodName": "DeleteActivity",
        "RequestParams": {
          "activityId": id
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
            console.error("Silme başarısız", error);
          });
    },
    closeTaskModal() {
      this.showTask = false;
      this.modalEntityJson = null;
      this.demandDetailId = null;
    },
    closeSourceModal() {
      this.showSource = false;
      this.modalEntitySourceJson = null;
      this.demandDetailId = null;
    },
    closeCommentModal() {
      this.showComment = false;
      this.modalEntityCommentJson = null;
    },
    closeActivityModal() {
      this.showActivity = false;
      this.modalEntityActivityJson = null;
    },
    newTaskOpenModal() {
      this.showTask = true;
    },
    newTaskActivityOpenModal() {
      this.showActivity = true;
    },
    newTaskCommentOpenModal() {
      this.showComment = true;
    },
    newTaskSourceOpenModal() {
      this.showSource = true;
    },
    createTableDemandDetail() {
      let self = this;
      let filterArray = [];
      filterArray.push({index: 1, value: '==' + self.$route.query.id})
      self.dataTableDemandDetail = self.createDataTables(
          $("#border-demand-detail-table"),
          "DemandDetailListOdata",
          0,
          self.columnsDemandDetail,
          filterArray, "and", '<t>'
      );
    },
    getListDemandDetail() {
      let self = this;

      self.columnsDemandDetail = [
        {mData: "Id", sType: "numeric", sTitle: "Görev No"},
        {mData: "DemandId", sType: "numeric", sTitle: "Talep No"},
        {mData: "TaskTypeName", sType: "string", sTitle: "Görev Tipi"},
        {mData: "TaskStatusName", sType: "string", sTitle: "Görev Durumu"},
        {
          bSearchable: false,
          render: function (data, type, row) {
            return '<div class="dropdown d-inline-block">\n' +
                '          <button class="btn btn-soft-primary btn-sm dropdown"\n' +
                '                  type="button" data-bs-toggle="dropdown"\n' +
                '                  aria-expanded="false">\n' +
                '            <i class="ri-more-fill align-middle"></i>\n' +
                '          </button>\n' +
                '          <ul class="dropdown-menu dropdown-menu-end">\n' +
                '            <li ><a id="addSource' + row.Id + '" data-bs-toggle="modal"\n' +
                '                   data-bs-target="#newSource"\n' +
                '                   href="javascript:void(0)"\n' +
                '                   class="dropdown-item edit-item-btn"><i\n' +
                '                class="ri-add-box-fill align-bottom me-2 text-muted"></i>\n' +
                '              Kaynak Ekle</a></li>\n' +
                '            <li ><a id="updateTask' + row.Id + '" data-bs-toggle="modal"\n' +
                '                   data-bs-target="#newTask"\n' +
                '                   href="javascript:void(0)"\n' +
                '                   class="dropdown-item edit-item-btn"><i\n' +
                '                class="ri-add-box-fill align-bottom me-2 text-muted"></i>\n' +
                '              Görev Güncelle</a></li>\n' +
                '            <li ><a id="deleteTask' + row.Id + '"\n' +
                '                   href="javascript:void(0)"\n' +
                '                   class="dropdown-item edit-item-btn"><i\n' +
                '                class="ri-delete-back-2-line align-bottom me-2 text-muted"></i>\n' +
                '              Görev Sil</a></li>\n' +
                '          </ul>\n' +
                '        </div>';

          }
        }

      ];
      self.createTableDemandDetail();
      $("#border-demand-detail-table tbody").on("dblclick", "tr", function () {
        var data = self.dataTable.row(this).data();
        self.dblclick(data.Id);
      });

      self.dataTableDemandDetail.on("click", "a", (e) => {
        if (e.currentTarget.id.indexOf("addSource") > -1) {
          self.rowNum = e.currentTarget.id.replace("addSource", "");

          self.demandDetailId = self.rowNum;
          self.getCompanyMaster();
          self.showSource = true;
        }
        if (e.currentTarget.id.indexOf("deleteTask") > -1) {
          self.rowNum = e.currentTarget.id.replace("deleteTask", "");
          self.deleteTask(self.rowNum.toString())
        }
        if (e.currentTarget.id.indexOf("updateTask") > -1) {

          self.rowNum = e.currentTarget.id.replace("updateTask", "");
          let config = {
            headers: {
              "Content-Type": "application/json"
            },
          };
          let reqdata = {
            "CorporateTypeName": "OperationDemand",
            "CorporateMethodName": "GetDemandDetail",
            "RequestParams": {
              "demandDetailId": self.rowNum
            }
          }

          appAxios.post(
              process.env.SERVICE_ADDRESS + "api/ProcessOperations/ProcessOperationPost",
              reqdata,
              config
          )
              // eslint-disable-next-line no-unused-vars
              .then(function (response) {
                self.modalEntityJson = response.data.Data;
                self.showTask = true;
              })
              .catch(function (error) {
                console.log(error);
                console.error("Kayıt başarısız", error);
              });
          self.demandDetailId = self.rowNum;
        }
      })
    },
    createTableDemandSource() {
      let self = this;
      let filterArray = [];
      filterArray.push({index: 1, value: '==' + self.$route.query.id})
      self.dataTableDemandSource = self.createDataTables(
          $("#border-demand-source-table"),
          "DemandSourceListOdata",
          0,
          self.columnsDemandSource,
          filterArray, "and", '<t>'
      );
    },
    getListDemandSource() {
      let self = this;
      self.columnsDemandSource = [
        {mData: "Id", sType: "numeric", sTitle: "Kaynak No"},
        {mData: "DemandId", sType: "numeric", sTitle: "Talep No"},
        {
          mData: "SourceUserName", sType: "string", sTitle: "Kaynak Kullanıcı",
          render: function (data) {
            if (data != null) {
              return data
            } else {
              return '-'
            }
          }
        },
        {
          mData: "SourceCompanyName", sType: "string", sTitle: "Kaynak Firma",
          render: function (data) {
            if (data != null) {
              return data
            } else {
              return '-'
            }
          }
        },
        {
          mData: "SourceTypeName", sType: "string", sTitle: "Kaynak Tipi",
          render: function (data) {
            if (data != null) {
              return data
            } else {
              return '-'
            }
          }
        },
        {mData: "DemandDetailId", sType: "numeric", sTitle: "Görev No"},
        {mData: "EstimatedEffortDay", sType: "numeric", sTitle: "Tahmini Efor(gün)"},
        {mData: "EstimatedDailyCost", sType: "decimal", sTitle: "Tahmini Günlük Maliyet"},
        {mData: "RealEffortDay", sType: "decimal", sTitle: "Gerçekleşen Efor(gün)"},
        {mData: "RealDailyCost", sType: "decimal", sTitle: "Gerçekleşen Günlük Maliyet"},
        {
          mData: "TaskTypeName", sType: "string", sTitle: "Görev Tipi"
        },
        {
          bSearchable: false,
          render: function (data, type, row) {
            return '<div class="dropdown d-inline-block">\n' +
                '          <button class="btn btn-soft-primary btn-sm dropdown"\n' +
                '                  type="button" data-bs-toggle="dropdown"\n' +
                '                  aria-expanded="false">\n' +
                '            <i class="ri-more-fill align-middle"></i>\n' +
                '          </button>\n' +
                '          <ul class="dropdown-menu dropdown-menu-end">\n' +
                '            <li ><a id="updateSource' + row.Id + '" data-bs-toggle="modal" data-demanddetailid="' + row.DemandDetailId + '" \n' +
                '                   data-bs-target="#newSource"\n' +
                '                   href="javascript:void(0)"\n' +
                '                   class="dropdown-item edit-item-btn"><i\n' +
                '                class="ri-add-box-fill align-bottom me-2 text-muted"></i>\n' +
                '              Kaynak Güncelle</a></li>\n' +
                '            <li ><a id="deleteSource' + row.Id + '" \n' +
                '                   href="javascript:void(0)"\n' +
                '                   class="dropdown-item edit-item-btn"><i\n' +
                '                class="ri-delete-back-2-fill align-bottom me-2 text-muted"></i>\n' +
                '              Kaynak Sil</a></li>\n' +
                '          </ul>\n' +
                '        </div>';

          }
        }


      ];
      self.createTableDemandSource();

      self.dataTableDemandSource.on("click", "a", (e) => {
        if (e.currentTarget.id.indexOf("deleteSource") > -1) {
          self.rowNum = e.currentTarget.id.replace("deleteSource", "");
          self.deleteSource(self.rowNum.toString())
        }

        if (e.currentTarget.id.indexOf("updateSource") > -1) {
          self.rowNum = e.currentTarget.id.replace("updateSource", "");
          self.demandDetailId = e.target.dataset.demanddetailid;
          let config = {
            headers: {
              "Content-Type": "application/json"
            },
          };
          let reqdata = {
            "CorporateTypeName": "OperationDemand",
            "CorporateMethodName": "GetDemandSource",
            "RequestParams": {
              "sourceId": self.rowNum
            }
          }

          appAxios.post(
              process.env.SERVICE_ADDRESS + "api/ProcessOperations/ProcessOperationPost",
              reqdata,
              config
          )
              // eslint-disable-next-line no-unused-vars
              .then(function (response) {
                self.modalEntitySourceJson = response.data.Data;
                self.showSource = true;
              })
              .catch(function (error) {
                console.log(error);
                console.error("Kayıt başarısız", error);
              });
          self.sourceId = self.rowNum;

        }
      })
    },
    createTableDemandComment() {
      let self = this;
      let filterArray = [];
      filterArray.push({index: 1, value: '==' + self.$route.query.id}, {index: 3, value: '==' + null})
      self.dataTableDemandComment = self.createDataTables(
          $("#border-demand-comment-table"),
          "DemandCommentOdata",
          0,
          self.columnsDemandComment,
          filterArray, "and", '<t>'
      );
    },
    createTableDemandActivity() {
      let self = this;
      let filterArray = [];
      filterArray.push({index: 1, value: '==' + self.$route.query.id})
      self.dataTableDemandActivity = self.createDataTables(
          $("#border-demand-activity-table"),
          "DemandActivityListOdata",
          0,
          self.columnsDemandActivity,
          filterArray, "and", '<t>'
      );
    },
    getListDemandComment() {
      let self = this;
      self.columnsDemandComment = [
        {mData: "Id", sType: "numeric", sTitle: "Yorum No"},
        {mData: "DemandId", sType: "numeric", sTitle: "Talep No"},
        {mData: "Description", sType: "string", sTitle: "Açıklama"},
        {mData: "DeletedTime", sType: "date", sTitle: "Silinme Tarihi", visible: false},
        {mData: "CreatedTime", sType: "date", sTitle: "Tarih",
          render:function (data){
            if (data!=null)
              return moment(data).format("YYYY-MM-DD")
          }
        },

        {
          bSearchable: false,
          render: function (data, type, row) {
            return '<div class="dropdown d-inline-block">\n' +
                '          <button class="btn btn-soft-primary btn-sm dropdown"\n' +
                '                  type="button" data-bs-toggle="dropdown"\n' +
                '                  aria-expanded="false">\n' +
                '            <i class="ri-more-fill align-middle"></i>\n' +
                '          </button>\n' +
                '          <ul class="dropdown-menu dropdown-menu-end">\n' +
                '            <li ><a id="updateComment' + row.Id + '" data-bs-toggle="modal"\n' +
                '                   data-bs-target="#newTaskComment"\n' +
                '                   href="javascript:void(0)"\n' +
                '                   class="dropdown-item edit-item-btn"><i\n' +
                '                class="ri-add-box-fill align-bottom me-2 text-muted"></i>\n' +
                '              Durum Güncelle</a></li>\n' +
                '            <li ><a id="deleteComment' + row.Id + '" + \n' +
                '                   href="javascript:void(0)"\n' +
                '                   class="dropdown-item edit-item-btn"><i\n' +
                '                class="ri-delete-back-2-line align-bottom me-2 text-muted"></i>\n' +
                '              Durum Sil</a></li>\n' +
                '          </ul>\n' +
                '        </div>';

          }
        }
      ];
      self.createTableDemandComment();
      self.dataTableDemandComment.on("click", "a", (e) => {
        if (e.currentTarget.id.indexOf("deleteComment") > -1) {
          self.rowNum = e.currentTarget.id.replace("deleteComment", "");
          self.deleteComment(self.rowNum.toString())
        }
        if (e.currentTarget.id.indexOf("updateComment") > -1) {

          self.rowNum = e.currentTarget.id.replace("updateComment", "");
          let config = {
            headers: {
              "Content-Type": "application/json"
            },
          };
          let reqdata = {
            "CorporateTypeName": "OperationDemand",
            "CorporateMethodName": "GetDemandComment",
            "RequestParams": {
              "commentId": self.rowNum
            }
          }

          appAxios.post(
              process.env.SERVICE_ADDRESS + "api/ProcessOperations/ProcessOperationPost",
              reqdata,
              config
          )
              // eslint-disable-next-line no-unused-vars
              .then(function (response) {
                self.modalEntityCommentJson = response.data.Data;
                self.showComment = true;
              })
              .catch(function (error) {
                console.log(error);
                console.error("Kayıt başarısız", error);
              });
          self.commentId = self.rowNum;
        }
      })
    },
    getListDemandActivity() {
      let self = this;
      self.columnsDemandActivity= [
        {mData: "Id", sType: "numeric", sTitle: "Aktivite No"},
        {mData: "DemandId", sType: "numeric", sTitle: "Talep No"},
        {mData: "Description", sType: "string", sTitle: "Açıklama"},
        {mData: "DeletedTime", sType: "date", sTitle: "Silinme Tarihi", visible: false},
        {mData: "Activityusername", sType: "string", sTitle: "Kişi"},
        {mData: "Statusid", sType: "string", sTitle: "Durum"},
        {mData: "EndDate", sType: "date", sTitle: "Tarih"},
        {
          bSearchable: false,
          render: function (data, type, row) {
            return '<div class="dropdown d-inline-block">\n' +
                '          <button class="btn btn-soft-primary btn-sm dropdown"\n' +
                '                  type="button" data-bs-toggle="dropdown"\n' +
                '                  aria-expanded="false">\n' +
                '            <i class="ri-more-fill align-middle"></i>\n' +
                '          </button>\n' +
                '          <ul class="dropdown-menu dropdown-menu-end">\n' +
                '            <li ><a id="updateActivity' + row.Id + '" data-bs-toggle="modal"\n' +
                '                   data-bs-target="#newTaskActivity"\n' +
                '                   href="javascript:void(0)"\n' +
                '                   class="dropdown-item edit-item-btn"><i\n' +
                '                class="ri-add-box-fill align-bottom me-2 text-muted"></i>\n' +
                '              Aktivite Güncelle</a></li>\n' +
                '            <li ><a id="deleteActivity' + row.Id + '" + \n' +
                '                   href="javascript:void(0)"\n' +
                '                   class="dropdown-item edit-item-btn"><i\n' +
                '                class="ri-delete-back-2-line align-bottom me-2 text-muted"></i>\n' +
                '              Aktivite Sil</a></li>\n' +
                '          </ul>\n' +
                '        </div>';

          }
        }
      ];
      self.createTableDemandActivity();
      self.dataTableDemandActivity.on("click", "a", (e) => {
        if (e.currentTarget.id.indexOf("deleteActivity") > -1) {
          self.rowNum = e.currentTarget.id.replace("deleteActivity", "");
          self.deleteActivity(self.rowNum.toString())
        }
        if (e.currentTarget.id.indexOf("updateActivity") > -1) {

          self.rowNum = e.currentTarget.id.replace("updateActivity", "");
          let config = {
            headers: {
              "Content-Type": "application/json"
            },
          };
          let reqdata = {
            "CorporateTypeName": "OperationDemand",
            "CorporateMethodName": "GetDemandActivity",
            "RequestParams": {
              "commentId": self.rowNum
            }
          }

          appAxios.post(
              process.env.SERVICE_ADDRESS + "api/ProcessOperations/ProcessOperationPost",
              reqdata,
              config
          )
              // eslint-disable-next-line no-unused-vars
              .then(function (response) {
                self.modalEntityActivityJson = response.data.Data;
                self.showActivity = true;
              })
              .catch(function (error) {
                console.log(error);
                console.error("Kayıt başarısız", error);
              });
          self.activityId = self.rowNum;
        }
      })
    },

    dblclick(dataId) {
      let self = this;
      self.$router.push({name: 'new-demand', query: {id: dataId}});
    },
    save() {
      let self = this;
      appAxios.post(process.env.SERVICE_ADDRESS + "api/Demand", self.entityModel).then(function (response) {
        window.location.assign(self.$route.path + "?id=" + response.data.Data.Id)
      }).catch(function (error) {
        console.log(error);
      });
    },
    update() {
      let self = this;
      appAxios.put(process.env.SERVICE_ADDRESS + "api/Demand", self.entityModel).then(function (response) {
        window.location.assign(self.$route.path + "?id=" + response.data.Data.Id)
      }).catch(function (error) {
        console.log(error);
      });
    },
    getRecord: function () {
      let self = this;
      let routeId = self.$route.query.id;
      console.log(routeId)
      if (routeId == undefined) {
        let config = {
          headers: {
            "controllerName": "demandmaster",
          },
        };
        const path = process.env.SERVICE_ADDRESS + "GetMeta";
        appAxios.get(path, config).then((res) => {
          self.entityModel = JSON.parse(String(res.data));
          self.entityModel.UserId = 1017;
          self.entityModel.Id = 0;
        }).catch((error) => console.log(error.data));
      } else {
        appAxios.get(process.env.SERVICE_ADDRESS + "api/Demand?id=" + routeId).then((res) => {
          self.entityModel = res.data.Data
        }).catch((error) => console.log(error.data));
      }
    },
    countdown: function () {
      this.remainingCount = this.maxCount - this.message.length;
      this.hasError = this.remainingCount < 0;
    },
    // getApplications() {
    //   let self = this;
    //   appAxios.get(process.env.SERVICE_ADDRESS + "odata/Application?$select=Name,Id")
    //       .then(({data}) => {
    //         let respose = data.value;
    //         for (let index = 0; index < respose.length; index++) {
    //           let addItem = {
    //             value: respose[index].Id,
    //             label: respose[index].Name,
    //           };
    //           self.applications.push(addItem);
    //         }
    //       })
    //       .catch((err) => {
    //         console.log(err);
    //       });
    // },
  },

  async created() {
    let self = this;
    self.getRecord();
    await self.getDepartments().then((res) => {
      self.departments = res;
    });
    await self.getUsers().then((res) => {
      self.users = res;
    });
    await self.getApplications().then((res) => {
      self.applications = res;
    });

    // await self.getCompanyMaster().then((res) => {
    //   self.companyMaster = res;
    // });
  },

};
</script>

<style scoped>
@font-face {
  font-family: "Nunito";
  src: url("https://fonts.googleapis.com/css2?family=Nunito:wght@300;400;500;600;700&display=swap");
}

.font {
  font-family: "Nunito", sans-serif;
}

textarea::placeholder {
  color: red !important;
  opacity: 0.5 !important;
}
</style>
