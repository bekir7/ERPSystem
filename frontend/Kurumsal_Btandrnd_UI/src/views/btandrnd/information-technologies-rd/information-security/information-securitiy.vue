<script>

import { defineAsyncComponent } from "vue";

const Layout = defineAsyncComponent(() => import("kurumsalbody/Layout"));
const PageHeader = defineAsyncComponent(() => import("kurumsalbody/PageHeader"));

import axios from "axios";
import appConfig from "@/../app.config";


export default {
  page: {
    title: "Proje Yönetimi",
    meta: [{ name: "description", content: appConfig.description }],
  },
  data() {
    return {
      chooseOption: null,
      title: "PROJE TAKİP",
      items: [
        {
          text: "Service Management",
          href: "/",
        },
        {
          text: "Project Management",
          active: true,
        },
      ],
      projectListings: [],


    };
  },
  components: {
    Layout,
    PageHeader,
  },

  mounted() {
    setTimeout(() => {
      this.getProjectListing();
    }, 100);
  },
  methods: {
    getProjectListing() {
            axios
                .get("https://jsonplaceholder.typicode.com/posts")
                .then(({ data }) => {
                    this.projectListings = data;
                    this.$nextTick(() => {
                        $("#myProjectListingTable").DataTable({
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
    <div class="row">
      <div class="col-lg-12">
        <div class="card">
          <div class="card-body">
            <button type="button" class="btn btn-soft-dark waves-effect waves-light btn-sm" data-bs-toggle="modal"
              data-bs-target="#newProjectModalgrid">
              <i class="ri-add-line label-icon align-middle fs-16 me-2"></i>
              {{ $t("t-new-project-registration") }}
            </button> <br><br>
            <!--modal -->
            <div class="modal zoomIn" id="newProjectModalgrid" tabindex="-1" aria-labelledby="exampleModalgridLabel"
              aria-modal="true">

              <div class="modal-dialog modal-xl">
                <div class="modal-content">
                  <div class="modal-header" style="background-color: #F1F1F1;">
                    <h5 class="modal-title" id="exampleModalgridLabel">
                      {{ $t("t-new-project-registration") }}
                    </h5>
                    <hr />
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                  </div>
                  <div class="modal-body" style="background-color: #F1F1F1;">
                    <div class="card">
                      <div class="card-header align-items-center d-flex">
                        <h4 class="card-title mb-0 flex-grow-1">{{ $t("t-project-information") }}</h4>

                        <button type="radio" class="btn btn-outline-primary">Notlar</button>
                        <button type="button" style="margin-left: 5px"
                          class="btn btn-outline-primary">Maliyetler</button>
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
                                        <div class="col-xxl-6">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-project-type") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsTip"
                                              id="exampleDataListTip" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsTip">
                                              <option :value="$t('t-project-request')">
                                              </option>
                                              <option :value="$t('t-project')">
                                              </option>

                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-6">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-project-year") }}</label>
                                            <input type="number" class="form-control form-control-sm" id="yilInput" />
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-request-category") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsİstek"
                                              id="exampleDataListİstek" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsİstek">
                                              <option :value="$t('t-system-improvement')">
                                              </option>
                                              <option :value="$t('t-improvement')">
                                              </option>
                                              <option :value="$t('t-new-process')">
                                              </option>
                                              <option :value="$t('t-institutional-obligation')">
                                              </option>
                                              <option :value="$t('t-legal-obligation')">
                                              </option>
                                              <option :value="$t('t-new-customer')">
                                              </option>
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-project-name-") }}</label>
                                            <input type="text" class="form-control form-control-sm" id="textInput" />
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-request-arrival-date") }}</label>
                                            <input type="date" class="form-control form-control-sm" id="dateInput" />
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-spoce") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsKapsam"
                                              id="exampleDataListKapsam" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsKapsam">
                                              <option :value="$t('t-external-customer')">
                                              </option>
                                              <option :value="$t('t-infrastructure')">
                                              </option>
                                              <option :value="$t('t-software-infrastructure')">
                                              </option>
                                              <option :value="$t('t-internal-customer')">
                                              </option>
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-project-supervisor") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsYonetici"
                                              id="exampleDataListYonetici" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsYonetici">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-deadline") }}</label>
                                            <input type="date" class="form-control form-control-sm" id="dateInput" />
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-customer-name") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsAd"
                                              id="exampleDataListAd" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsAd">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-expected-date") }}</label>
                                            <input type="date" class="form-control form-control-sm" id="dateInput" />
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-actual-delivery-date") }}</label>
                                            <input type="date" class="form-control form-control-sm" id="dateInput" />
                                          </div>
                                        </div>
                                        <div class="col-lg-12">
                                          <label for="aciklamaInput" class="form-label">{{
                                              $t("t-departments-affected")
                                          }}</label>
                                          <textarea class="form-control" id="exampleFormControlTextarea5"
                                            rows="1"></textarea>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-use") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsFaydaa"
                                              id="exampleDataListFaydaa" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsFaydaa">
                                              <option :value="$t('t-financial-benefit')">
                                              </option>
                                              <option :value="$t('t-operational-benefit')">
                                              </option>

                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-situadtion") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsDurum"
                                              id="exampleDataListDurum" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsDurum">
                                              <option :value="$t('t-demand-under-evaluation')">
                                              </option>
                                              <option :value="$t('t-request-approved')">
                                              </option>
                                              <option :value="$t('t-new-process')">
                                              </option>
                                              <option value="Test">
                                              </option>
                                              <option :value="$t('t-cancel')">
                                              </option>
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-analysis-documentation") }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsAnaliz"
                                              id="exampleDataListAnaliz" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsAnaliz">
                                              <option :value="$t('t-yes')">
                                              </option>
                                              <option :value="$t('t-no')">
                                              </option>
                                            </datalist>
                                          </div>
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
            <!-- tablo -->
            <div class="card-body">
              <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
                <div class="d-flex">
                  <div class="flex-grow-1 ms-2">
                    <div class="row">
                      <div class="card card-body">
                        <div class="card-body">
                          <div class=" table-responsive table-card" style="width: 100% !important">
                            <table style="width: 100% !important; margin-right: -500px; " id="myProjectListingTable"
                              class="listingTable table align-middle table-nowrap">
                              <thead class="table-light text-muted">
                                <tr>
                                  <th class="sort" scope="col">{{ $t("t-code") }}</th>
                                  <th class="sort" scope="col">{{ $t("t-added-date") }}</th>
                                  <th class="sort" scope="col">{{ $t("t-project-name-") }}</th>
                                  <th class="sort" scope="col">{{ $t("t-customer-name") }}</th>
                                  <th class="sort" scope="col">{{ $t("t-spoce") }}</th>
                                  <th class="sort" scope="col">{{ $t("t-project-supervisor") }}</th>
                                  <th class="sort" scope="col">{{ $t("t-use") }}</th>
                                  <th class="sort" scope="col">{{ $t("t-situadtion") }}</th>
                                </tr>
                              </thead>
                              <tbody class="list form-check-all">
                                <tr v-for="projectListing in projectListings" :key="projectListing.id">
                                  <td>{{ projectListing.id }}</td>
                                  <td>{{ projectListing.id }}</td>
                                  <td>{{ projectListing.id }}</td>
                                  <td>{{ projectListing.id }}</td>
                                  <td>{{ projectListing.id }}</td>
                                  <td>{{ projectListing.title }}</td>
                                  <td>{{ projectListing.id }}</td>
                                  <td>{{ projectListing.id }}</td>
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
  </Layout>

</template>