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
    title: "Risk Yönetimi",
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
      title: this.$t("t-risk-management"),
      items: [
        {
          text: this.$t("t-service-management"),
          href: "/",
        },
        {
          text: this.$t("t-risk-management"),
          active: true,
        },
      ],
      myRisks: [],
      reviews: [],

    };
  },
  components: {
    Layout,
    PageHeader,
  },

  mounted() {
    setTimeout(() => {
      this.getMyRisk();
      this.getMyReview();
    }, 100);
  },
  methods: {
    getMyRisk() {
      axios
        .get("https://jsonplaceholder.typicode.com/posts")
        .then(({ data }) => {
          this.myRisks = data;
          this.$nextTick(() => {
            $("#myMyRiskTable").DataTable({
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
    getMyReview() {
      axios
        .get("https://jsonplaceholder.typicode.com/posts/1")
        .then(({ data }) => {
          this.reviews = data;
          this.$nextTick(() => {
            $("#myReviewTable").DataTable({
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
              data-bs-target="#newRiskModalgrid">
              <i class="ri-add-line label-icon align-middle fs-16 me-2"></i>
              {{ $t("t-new-risk-record") }}
            </button> <br><br>
            <!--modal -->
            <div class="modal zoomIn" id="newRiskModalgrid" tabindex="-1" aria-labelledby="exampleModalgridLabel"
              aria-modal="true">

              <div class="modal-dialog modal-xl">
                <div class="modal-content">
                  <div class="modal-header" style="background-color: #F1F1F1;">
                    <h5 class="modal-title" id="exampleModalgridLabel">
                      {{ $t("t-new-risk-record") }}
                    </h5>
                    <hr />
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                  </div>
                  <div class="modal-body" style="background-color: #F1F1F1;">
                    <div class="card">
                      <div class="card-header align-items-center d-flex">
                        <h4 class="card-title mb-0 flex-grow-1">{{ $t("t-risk-detail")
                        }}
                        </h4>
                      </div>
                      <div class="card-body">
                        <div class="row g-3">
                          <div class="col-xxl-3">
                            <div>
                              <label for="birim" class="form-label form-label-sm">
                                {{ $t("t-risk-name") }}</label>
                              <input type="text" class="form-control form-control-sm" />
                            </div>
                          </div>
                          <div class="col-xxl-3">
                            <div>
                              <label for="birim" class="form-label form-label-sm">
                                {{ $t("t-risk-category") }}</label>
                              <input class="form-control form-control-sm" list="datalistOptionRcategory"
                                id="exampleDataListOptionRcategory" :placeholder="$t('t-choose')" />
                              <datalist id="datalistOptionRcategory">
                                <option :value="$t('t-financial')">
                                </option>
                                <option :value="$t('t-strategic')">
                                </option>
                                <option :value="$t('t-operational')">
                                </option>
                              </datalist>
                            </div>
                          </div>
                          <div class="col-xxl-3">
                            <div>
                              <label for="birim" class="form-label form-label-sm">
                                {{ $t("t-source-of-risk") }}</label>
                              <input class="form-control form-control-sm" list="datalistOptionRsource"
                                id="exampleDataListOptionRsource" :placeholder="$t('t-choose')" />
                              <datalist id="datalistOptionRsource">
                                <option :value="$t('t-period')">
                                </option>
                                <option :value="$t('t-entity')">
                                </option>
                              </datalist>
                            </div>
                          </div>
                          <div class="col-xxl-3">
                            <div>
                              <label for="birim" class="form-label form-label-sm">
                                {{ $t("t-regulation") }}</label>
                              <input type="text" class="form-control form-control-sm" />
                            </div>
                          </div>
                          <div class="col-xxl-3">
                            <div>
                              <label for="birim" class="form-label form-label-sm">
                                {{ $t("t-responsible-group") }}</label>
                              <input type="text" class="form-control form-control-sm" />
                            </div>
                          </div>
                          <div class="col-xxl-3">
                            <div>
                              <label for="birim" class="form-label form-label-sm">
                                {{ $t("t-person-charge") }}</label>
                              <input type="text" class="form-control form-control-sm" />
                            </div>
                          </div>

                          <div class="col-xxl-3">
                            <div>
                              <label for="birim" class="form-label form-label-sm">
                                {{ $t("t-related-entity") }}</label>
                              <input type="text" class="form-control form-control-sm" />
                            </div>
                          </div>
                          <div class="col-xxl-3">
                            <div>
                              <label for="birim" class="form-label form-label-sm">
                                {{ $t("t-security") }}</label>
                              <input type="text" class="form-control form-control-sm" />
                            </div>
                          </div>
                          <div class="col-xxl-3">
                            <div>
                              <label for="birim" class="form-label form-label-sm">
                                {{ $t("t-integrity") }}</label>
                              <input type="text" class="form-control form-control-sm" />
                            </div>
                          </div>
                          <div class="col-xxl-3">
                            <div>
                              <label for="birim" class="form-label form-label-sm">
                                {{ $t("t-accessibility") }}</label>
                              <input type="text" class="form-control form-control-sm" />
                            </div>
                          </div>
                          <div class="col-xxl-3">
                            <div>
                              <label for="birim" class="form-label form-label-sm">
                                {{ $t("t-data-privacy-level") }}</label>
                              <input type="text" class="form-control form-control-sm" />
                            </div>
                          </div>

                          <div class="col-xxl-3">
                            <div>
                              <label for="birim" class="form-label form-label-sm">
                                {{ $t("t-risk-level") }}</label>
                              <input type="text" class="form-control form-control-sm" />
                            </div>
                          </div>
                          <div class="col-xxl-12">
                            <label for="aciklamaInput" class="form-label"> {{
                                $t("t-explanation")
                            }}
                            </label>
                            <textarea class="form-control" id="exampleFormControlTextarea5" rows="3"></textarea>
                          </div>
                        </div>
                      </div>
                    </div>
                    <!-- tablo -->
                    <div class="card">
                      <div class="card-header align-items-center d-flex">
                        <h4 class="card-title mb-0 flex-grow-1">{{ $t("t-review-list") }}
                        </h4>
                      </div>
                      <div class="card-body">
                        <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
                          <div class="d-flex">
                            <div class="flex-grow-1 ms-2">
                              <div class="row">
                                <div class="card card-body">
                                  <div class="card-body">
                                    <div class="table-responsive table-card" style="width: 100% !important">
                                      <table style="width: 100% !important; margin-right: -200px;" id="myReviewTable"
                                        class="listingTable table align-middle table-nowrap">
                                        <thead class="table-light text-muted">
                                          <tr>
                                            <th class="sort" scope="col">
                                              Risk
                                            </th>
                                            <th class="sort" scope="col">{{
                                                $t("t-comment-date")
                                            }}
                                            </th>
                                            <th class="sort" scope="col">{{
                                                $t("t-review-date")
                                            }}
                                            </th>
                                            <th class="sort" scope="col">{{
                                                $t("t-attendees")
                                            }}
                                            </th>
                                            <th class="sort" scope="col">{{
                                                $t("t-action-plan-details")
                                            }}
                                            </th>
                                          </tr>
                                        </thead>
                                        <tbody class="list form-check-all">
                                          <tr v-for="review in reviews" :key="review.id">
                                            <td>{{ review.id }}
                                            </td>
                                            <td>{{ review.id }}
                                            </td>
                                            <td>{{ review.id }}
                                            </td>
                                            <td>{{ review.id }}
                                            </td>
                                            <td>{{ review.id }}
                                            </td>
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
                    <div class="card">
                      <div class="card-header align-items-center d-flex">
                        <h4 class="card-title mb-0 flex-grow-1"> {{ $t("t-prevention-plan")
                        }}
                        </h4>
                      </div>
                      <div class="card-body">
                        <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
                          <div class="d-flex">
                            <div class="flex-grow-1 ms-2">
                              <div class="row">
                                <div class="card-body ">
                                  <div class=" table-responsive table-card" style="width: 100% !important">
                                    <div class="card-body">
                                      <div class="row g-3">
                                        <div class="col-xxl-6">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-plan-strategy")
                                              }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionStrategy"
                                              id="exampleDataListOptionStrategy" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionStrategy">
                                              <option :value="$t('t-change')">
                                              </option>
                                              <option :value="$t('t-check-up')">
                                              </option>
                                              <option :value="$t('t-project')">
                                              </option>
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-6">
                                          <div>
                                            <label for="lastName" class="form-label">{{
                                                $t("t-plan-owner")
                                            }}</label>
                                            <input type="text" class="form-control form-control-sm" />
                                          </div>
                                        </div>
                                        <div class="col-xxl-12">
                                          <label for="aciklamaInput" class="form-label"> {{
                                              $t("t-action-plan-details")
                                          }}
                                          </label>
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
                    <!-- gozden gecir modal -->
                    <div class="card">
                      <div class="card-header align-items-center d-flex">
                        <h4 class="card-title mb-0 flex-grow-1"> {{ $t("t-risk-information") }}
                        </h4>
                      </div>
                      <div class="card-body">
                        <div class="row g-3">
                          <div class="col-xxl-8">
                            <div>
                              <label for="birim" class="form-label form-label-sm">
                                {{ $t("t-situation") }}</label>
                              <input class="form-control form-control-sm" list="datalistOptionRsituation"
                                id="exampleDataListOptionRsituation" :placeholder="$t('t-choose')" />
                              <datalist id="datalistOptionRsituation">
                                <option :value="$t('t-reject-and-close')">
                                </option>
                                <option :value="$t('t-accept-the-risk')">
                                </option>
                              </datalist>
                            </div>
                          </div>
                          <div class="col-lg-8">
                            <label for="aciklamaInput" class="form-label">{{
                                $t("t-action-plan-details")
                            }}</label>
                            <textarea class="form-control" id="exampleFormControlTextarea5" rows="2"></textarea>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <!-- filtreleme olacak -->
            <div class="row g-3 ">
              <div class="col-xxl-2">
                    <div>
                      <label class="form-label"> {{ $t("t-category") }}</label>
                      <input
                        class="form-control form-control-sm"
                        list="datalistCategoryRiskMan"
                        id="exampleDataList"
                        :placeholder="$t('t-choose')"
                      />
                      <datalist id="datalistCategoryRiskMan"> </datalist>
                    </div>
                  </div>
                  <div class="col-xxl-2">
                    <div>
                      <label class="form-label"> {{ $t("t-responsible-group") }}</label>
                      <input
                        class="form-control form-control-sm"
                        list="datalistResponsibleGroupRiskMan"
                        id="exampleDataList"
                        :placeholder="$t('t-choose')"
                      />
                      <datalist id="datalistResponsibleGroupRiskMan"> </datalist>
                    </div>
                  </div>
                  <div class="col-xxl-2">
                    <div>
                      <label class="form-label"> {{ $t("t-person-charge") }}</label>
                      <input
                        class="form-control form-control-sm"
                        list="datalistPersonChargeRiskMan"
                        id="exampleDataList"
                        :placeholder="$t('t-choose')"
                      />
                      <datalist id="datalistPersonChargeRiskMan"> </datalist>
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
                            <table style="width: 100% !important; margin-right: -200px;" id="myMyRiskTable"
                              class="listingTable table align-middle table-nowrap">
                              <thead class="table-light text-muted">
                                <tr>
                                  <th class="sort" scope="col">{{
                                      $t("t-risk-situation")
                                  }}</th>
                                  <th class="sort" scope="col">{{
                                      $t("t-code")
                                  }}</th>
                                  <th class="sort" scope="col">{{
                                      $t("t-risk-name")
                                  }}
                                  </th>
                                  <th class="sort" scope="col">{{
                                      $t("t-risk-category")
                                  }}
                                  </th>
                                  <th class="sort" scope="col">{{
                                      $t("t-responsible-group")
                                  }}
                                  </th>
                                  <th class="sort" scope="col">{{
                                      $t("t-person-charge")
                                  }}
                                  </th>
                                  <th class="sort" scope="col">{{
                                      $t("t-regulation")
                                  }}
                                  </th>
                                  <th class="sort" scope="col">{{
                                      $t("t-source-of-risk")
                                  }}
                                  </th>
                                </tr>
                              </thead>
                              <tbody class="list form-check-all">
                                <tr v-for="myRisk in myRisks" :key="myRisk.id">
                                  <td>{{ myRisk.id }}</td>
                                  <td>{{ myRisk.id }}</td>
                                  <td>{{ myRisk.id }}</td>
                                  <td>{{ myRisk.id }}</td>
                                  <td>{{ myRisk.id }}</td>
                                  <td>{{ myRisk.id }}</td>
                                  <td>{{ myRisk.id }}</td>
                                  <td>{{ myRisk.id }}</td>

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
