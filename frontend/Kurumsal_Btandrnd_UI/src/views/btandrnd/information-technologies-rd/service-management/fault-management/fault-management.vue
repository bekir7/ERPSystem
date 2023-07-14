<script>

import { defineAsyncComponent } from "vue";

const Layout = defineAsyncComponent(() => import("kurumsalbody/Layout"));
const PageHeader = defineAsyncComponent(() => import("kurumsalbody/PageHeader"));
import axios from "axios";
import appConfig from "@/../app.config";
//import DataTable from 'datatables.net-bs5';
import $ from 'jquery'; 

export default {
  page: {
    title: "Arıza Yönetimi",
    meta: [
      {
        name: "description",
        content: appConfig.description,
      },
    ],
  },
  data() {
    return {
      chooseOption: null,
      title: this.$t("t-fault-management"),
      items: [
        {
          text: this.$t("t-service-management"),
          href: "/",
        },
        {
          text: this.$t("t-fault-management"),
          active: true,
        },
      ],
      changeListings: [],
    };
  },
  components: {
    Layout,
    PageHeader,
  },

  mounted() {
    setTimeout(() => {
      this.getMyDemand();
      this.getMyRequest();

    }, 100);
  },
  methods: {
    getMyDemand() {
      axios
        .get("https://jsonplaceholder.typicode.com/posts")
        .then(({ data }) => {
          this.myDemands = data;
          this.$nextTick(() => {
            $("#myMyDemandTable").DataTable({
              responsive: true,
              language: {
                emptyTable: "Gösterilecek veri yok.",
                processing: "Veriler yükleniyor...",
                sDecimal: ".",
                sInfo:
                  "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor.",
                sInfoFiltered: "(_MAX_ kayıt içerisinden bulunan)",
                sInfoPostFix: "",
                sInfoThousands: ".",
                sLengthMenu: "Sayfada _MENU_ kayıt göster",
                sLoadingRecords: "Yükleniyor...",
                sSearch: "Ara:",
                sZeroRecords: "Eşleşen kayıt bulunamadı.",
                oPaginate: {
                  sFirst: "İlk",
                  sLast: "Son",
                  sNext: "Sonraki",
                  sPrevious: "Önceki",
                },
                oAria: {
                  sSortAscending: ": artan sütun sıralamasını aktifleştir.",
                  sSortDescending: ": azalan sütun sıralamasını aktifleştir.",
                },
                select: {
                  rows: {
                    _: "%d kayıt seçildi.",
                    0: "",
                    1: "1 kayıt seçildi.",
                  },
                },
              },
            });
          });
        })
        .catch((error) => console.log(error.data));
    },
    getMyRequest() {
      axios
        .get("https://jsonplaceholder.typicode.com/posts")
        .then(({ data }) => {
          this.requests = data;
          this.$nextTick(() => {
            $("#myRequestTable").DataTable({
              responsive: true,
              language: {
                emptyTable: "Gösterilecek veri yok.",
                processing: "Veriler yükleniyor...",
                sDecimal: ".",
                sInfo:
                  "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor.",
                sInfoFiltered: "(_MAX_ kayıt içerisinden bulunan)",
                sInfoPostFix: "",
                sInfoThousands: ".",
                sLengthMenu: "Sayfada _MENU_ kayıt göster",
                sLoadingRecords: "Yükleniyor...",
                sSearch: "Ara:",
                sZeroRecords: "Eşleşen kayıt bulunamadı.",
                oPaginate: {
                  sFirst: "İlk",
                  sLast: "Son",
                  sNext: "Sonraki",
                  sPrevious: "Önceki",
                },
                oAria: {
                  sSortAscending: ": artan sütun sıralamasını aktifleştir.",
                  sSortDescending: ": azalan sütun sıralamasını aktifleştir.",
                },
                select: {
                  rows: {
                    _: "%d kayıt seçildi.",
                    0: "",
                    1: "1 kayıt seçildi.",
                  },
                },
              },
            });
          });
        })
        .catch((error) => console.log(error.data));
    },

  },
};
</script>

<template>
  <Layout>
    <PageHeader :title="title" :items="items" />
    <div class="row font">
      <div class="col-lg-12">
        <div class="card">
          <div class="card-body">
            <button type="button" class="btn btn-soft-dark waves-effect waves-light btn-sm" data-bs-toggle="modal"
              data-bs-target="#newCreateRequestModalgrid">
              <i class="ri-add-line label-icon align-middle fs-16 me-2"></i>
              {{ $t("t-create-new-request") }}
            </button>
            <button style="margin-left: 10px" type="button" class="btn btn-soft-dark waves-effect waves-light btn-sm"
              data-bs-toggle="modal" data-bs-target="#newAssignRequestModalgrid">
              <i class="ri-add-line label-icon align-middle fs-16 me-2"></i>
              {{ $t("t-assign-new-request") }}
            </button>
            <br><br>
            <!-- YENİ TALEP OLUŞTUR MODAL -->
            <div class="modal zoomIn" id="newCreateRequestModalgrid" tabindex="-1"
              aria-labelledby="exampleModalgridLabel" aria-modal="true">

              <div class="modal-dialog modal-xl">
                <div class="modal-content">
                  <div class="modal-header" style="background-color: #F1F1F1;">
                    <h5 class="modal-title" id="exampleModalgridLabel">
                      {{ $t("t-create-new-request") }}
                    </h5>
                    <hr />
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                  </div>
                  <div class="modal-body" style="background-color: #F1F1F1;">
                    <div class="card">
                      <div class="card-header align-items-center d-flex">
                        <h4 class="card-title mb-0 flex-grow-1">{{ $t("t-request-detail") }}</h4>
                      </div>
                      <div class="card-body">
                        <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
                          <div class="d-flex">
                            <div class="flex-grow-1 ms-2">
                              <div class="row">
                                <div class="card-body">
                                  <div class=" table-responsive table-card" style="width: 100% !important">
                                    <div class="card-body">
                                      <div class="row g-3">
                                        <div class="col-xxl-3">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-requested-department") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionDepartman"
                                              id="exampleDataListOptionDepartman" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionDepartman">
                                              <option :value="$t('t-operation-support')">
                                              </option>
                                              <option :value="$t('t-human-resources')">
                                              </option>
                                              <option :value="$t('t-information-technologies')">
                                              </option>
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-type") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsTip"
                                              id="exampleDataListTip" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsTip">
                                              <option :value="$t('t-care')">
                                              </option>
                                              <option :value="$t('t-unassigned')">
                                              </option>
                                              <option :value="$t('t-fault-notification')">
                                              </option>
                                              <option :value="$t('t-information-request')">
                                              </option>
                                              <option :value="$t('t-request-correction')">
                                              </option>
                                              <option :value="$t('t-request-software-change')">
                                              </option>
                                              <option :value="$t('t-human-resources-department-information')">
                                              </option>
                                            </datalist>
                                          </div>
                                        </div>

                                        <div class="col-xxl-3">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-category") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsKatagori"
                                              id="exampleDataListKatagori" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsKatagori">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-sub-category") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsAlt"
                                              id="exampleDataListAlt" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsAlt">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-priority") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsOnce"
                                              id="exampleDataListOnce" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsOnce">
                                              <option :value="$t('t-unassigned')">
                                              </option>
                                              <option :value="$t('t-low')">
                                              </option>
                                              <option value="Normal">
                                              </option>
                                              <option :value="$t('t-middle')">
                                              </option>
                                              <option :value="$t('t-high')">
                                              </option>
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-related-inventory") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsEnvanter"
                                              id="exampleDataListEnvanter" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsEnvanter">

                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-creation-date") }}</label>
                                            <input type="date" class="form-control form-control-sm" id="dateInput" />
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-reporting-fault") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsBildiren"
                                              id="exampleDataListBildiren" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsBildiren">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-lg-12">
                                          <label for="aciklamaInput" class="form-label">{{ $t("t-subject") }}</label>
                                          <textarea class="form-control" id="exampleFormControlTextarea5"
                                            rows="2"></textarea>
                                        </div>
                                        <div class="col-lg-12">
                                          <label for="aciklamaInput" class="form-label">{{ $t("t-explanation")
                                          }}</label>
                                          <textarea class="form-control" id="exampleFormControlTextarea5"
                                            rows="3"></textarea>
                                        </div>
                                        <div class="hstack gap-2 justify-content-end">
                                          <button type="button" class="btn btn-light" data-bs-dismiss="modal"
                                            id="degisiklikTalebiBtn">
                                            {{ $t("t-close") }}
                                          </button>
                                          <button type="submit" class="btn btn-primary" id="degisiklikTalebiBtn">
                                            {{ $t("t-save") }}
                                          </button>
                                        </div>
                                      </div>
                                    </div>
                                  </div>
                                </div>
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <!-- YENİ TALEP ATA MODAL -->
            <div class="modal zoomIn" id="newAssignRequestModalgrid" tabindex="-1"
              aria-labelledby="exampleModalgridLabel" aria-modal="true">

              <div class="modal-dialog modal-xl">
                <div class="modal-content">
                  <div class="modal-header" style="background-color: #F1F1F1;">
                    <h5 class="modal-title" id="exampleModalgridLabel">
                      {{ $t("t-create-new-request") }}
                    </h5>
                    <hr />
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                  </div>
                  <div class="modal-body" style="background-color: #F1F1F1;">
                    <div class="card">
                      <div class="card-header align-items-center d-flex">
                        <h4 class="card-title mb-0 flex-grow-1">{{ $t("t-request-detail") }}</h4>
                      </div>
                      <div class="card-body">
                        <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
                          <div class="d-flex">
                            <div class="flex-grow-1 ms-2">
                              <div class="row">
                                <div class="card-body">
                                  <div class=" table-responsive table-card" style="width: 100% !important">
                                    <div class="card-body">
                                      <div class="row g-3">
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-type") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsTip"
                                              id="exampleDataListTip" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsTip">
                                              <option :value="$t('t-care')">
                                              </option>
                                              <option :value="$t('t-unassigned')">
                                              </option>
                                              <option :value="$t('t-fault-notification')">
                                              </option>
                                              <option :value="$t('t-information-request')">
                                              </option>
                                              <option :value="$t('t-request-correction')">
                                              </option>
                                              <option :value="$t('t-request-software-change')">
                                              </option>
                                              <option :value="$t('t-human-resources-department-information')">
                                              </option>
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-requested-department") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionDepartman"
                                              id="exampleDataListOptionDepartman" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionDepartman">
                                              <option :value="$t('t-operation-support')">
                                              </option>
                                              <option :value="$t('t-human-resources')">
                                              </option>
                                              <option :value="$t('t-information-technologies')">
                                              </option>
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-category") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsKatagori"
                                              id="exampleDataListKatagori" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsKatagori">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-sub-category") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsAlt"
                                              id="exampleDataListAlt" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsAlt">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-element") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsOge"
                                              id="exampleDataListOge" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsOge">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-related-inventory") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsEnvanter"
                                              id="exampleDataListEnvanter" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsEnvanter">

                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-creation-date") }}</label>
                                            <input type="date" class="form-control form-control-sm" id="dateInput" />
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-team") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsTeam"
                                              id="exampleDataListTeam" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsTeam">

                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-assigned") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionAsssigned"
                                              id="exampleDataListAsssigned" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsAsssigned">

                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-reporting-fault") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsBildiren"
                                              id="exampleDataListBildiren" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsBildiren">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-priority") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsOnce"
                                              id="exampleDataListOnce" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsOnce">
                                              <option :value="$t('t-unassigned')">
                                              </option>
                                              <option :value="$t('t-low')">
                                              </option>
                                              <option value="Normal">
                                              </option>
                                              <option :value="$t('t-middle')">
                                              </option>
                                              <option :value="$t('t-high')">
                                              </option>
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-mailing-contacts") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsMail"
                                              id="exampleDataListMail" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsMail">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-analysis-date") }}</label>
                                            <input type="date" class="form-control form-control-sm" id="dateInput" />
                                          </div>
                                        </div>


                                        <div class="col-lg-12">
                                          <label for="aciklamaInput" class="form-label">{{ $t("t-subject") }}</label>
                                          <textarea class="form-control" id="exampleFormControlTextarea5"
                                            rows="2"></textarea>
                                        </div>
                                        <div class="col-lg-12">
                                          <label for="aciklamaInput" class="form-label">{{ $t("t-explanation")
                                          }}</label>
                                          <textarea class="form-control" id="exampleFormControlTextarea5"
                                            rows="3"></textarea>
                                        </div>
                                        <div class="hstack gap-2 justify-content-end">
                                          <button type="button" class="btn btn-light" data-bs-dismiss="modal"
                                            id="degisiklikTalebiBtn">
                                            {{ $t("t-close") }}
                                          </button>
                                          <button type="submit" class="btn btn-primary" id="degisiklikTalebiBtn">
                                            {{ $t("t-save") }}
                                          </button>
                                        </div>
                                      </div>
                                    </div>
                                  </div>
                                </div>
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <!-- Nav tabs -->
            <ul class="nav nav-tabs nav-justified mb-3" role="tablist">
              <li class="nav-item">
                <a class="nav-link active " data-bs-toggle="tab" href="#nav-badge-my-demands" role="tab"
                  aria-selected="true" style="font-size: 13px">
                  {{ $t("t-my-demands") }}
                  <span class="badge bg-success rounded-circle">5</span>
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link" data-bs-toggle="tab" href="#nav-badge-requests" role="tab" aria-selected="false"
                  style="font-size: 13px">  
                  {{ $t("t-requests") }}
                  <span class="badge bg-danger rounded-circle">5</span>
                </a>
              </li>
            </ul>

            <!-- Nav tabs -->
            <div class="tab-content text-muted">
              <div class="tab-pane active" id="nav-badge-my-demands" role="tabpanel">
                <!-- taleplerim tablo -->
                <div class="d-flex">
                  <div class="card-body">
                    <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
                      <div class="d-flex">
                        <div class="flex-grow-1 ms-2">
                          <div class="row">
                            <div class="card card-body">
                              <div class="card-body">
                                <div class=" table-responsive table-card" style="width: 100% !important">
                                  <table style="width: 100% !important; margin-right: -200px; " id="myMyDemandTable"
                                    class="listingTable table align-middle table-nowrap">
                                    <thead class="table-light text-muted">
                                      <tr>
                                        <th class="sort" scope="col">{{ $t("t-situation") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-code") }}</th>
                                        <th class="sort" scope="col"> {{ $t("t-subject") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-explanation") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-assigned") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-category") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-sub-category") }}</th>
                                      </tr>
                                    </thead>
                                    <tbody class="list form-check-all">
                                      <tr v-for="myDemand in myDemands" :key="myDemand.id">
                                        <td>{{ myDemand.id }}</td>
                                        <td>{{ myDemand.id }}</td>
                                        <td>{{ myDemand.id }}</td>
                                        <td>{{ myDemand.id }}</td>
                                        <td>{{ myDemand.id }}</td>
                                        <td>{{ myDemand.id }}</td>
                                        <td>{{ myDemand.id }}</td>
                                      </tr>
                                    </tbody>
                                  </table>
                                </div>
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>

                </div> 
             
              </div>

              <div class="tab-pane " id="nav-badge-requests" role="tabpanel">
                <!-- talepler tablo -->
                <div class="d-flex">
                  <div class="card-body">
                    <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
                      <div class="d-flex">
                        <div class="flex-grow-1 ms-2">
                          <div class="row">
                            <div class="card card-body">
                              <div class="card-body">
                                <div class=" table-responsive table-card" style="width: 100% !important">
                                  <table style="width: 100% !important; margin-right: -200px; " id="myRequestTable"
                                    class="listingTable table align-middle table-nowrap">
                                    <thead class="table-light text-muted">
                                      <tr>
                                        <th class="sort" scope="col">{{ $t("t-situation") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-code") }}</th>
                                        <th class="sort" scope="col"> {{ $t("t-subject") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-explanation") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-team") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-appointing") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-assigned") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-category") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-sub-category") }}</th>
                                      </tr>
                                    </thead>
                                    <tbody class="list form-check-all">
                                      <tr v-for="request in requests" :key="request.id">
                                        <td>{{ request.id }}</td>
                                        <td>{{ request.id }}</td>
                                        <td>{{ request.id }}</td>
                                        <td>{{ request.id }}</td>
                                        <td>{{ request.id }}</td>
                                        <td>{{ request.id }}</td>
                                        <td>{{ request.id }}</td>
                                        <td>{{ request.id }}</td>
                                        <td>{{ request.id }}</td>

                                      </tr>
                                    </tbody>
                                  </table>
                                </div>
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>

                </div>
               
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
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
