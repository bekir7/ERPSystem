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
    title: "Bilgi Bankası",
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
      title: this.$t("t-data-base"),
      items: [
        {
          text: this.$t("t-service-management"),
          href: "/",
        },
        {
          text: this.$t("t-data-base"),
          active: true,
        },
      ],
      dataBases: [],

    };
  },
  components: {
    Layout,
    PageHeader,
  },

  mounted() {
    setTimeout(() => {
      this.getDataBase();

    }, 100);
  },
  methods: {
    getDataBase() {
      axios
        .get("https://jsonplaceholder.typicode.com/posts")
        .then(({ data }) => {
          this.dataBases = data;
          this.$nextTick(() => {
            $("#myDataBaseTable").DataTable({
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
              data-bs-target="#newDataBaseModalgrid">
              <i class="ri-add-line label-icon align-middle fs-16 me-2"></i>
              {{ $t("t-create-new-record") }}
            </button> <br><br>
            <!--modal -->
            <div class="modal zoomIn" id="newDataBaseModalgrid" tabindex="-1" aria-labelledby="exampleModalgridLabel"
              aria-modal="true">

              <div class="modal-dialog modal-lg">
                <div class="modal-content">
                  <div class="modal-header" style="background-color: #F1F1F1;">
                    <h5 class="modal-title" id="exampleModalgridLabel">
                      {{ $t("t-create-new-record") }}
                    </h5>
                    <hr />
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                  </div>
                  <div class="modal-body" style="background-color: #F1F1F1;">
                    <div class="card">
                      <div class="card-header align-items-center d-flex">
                        <h4 class="card-title mb-0 flex-grow-1"> {{ $t("t-adding-documents") }}
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

                                        <div class="col-xxl-12">
                                          <div>
                                            <label for="birim" class="form-label form-label-sm">
                                              {{ $t("t-category")
                                              }}</label>
                                            <input class="form-control form-control-sm" list="datalistOptionsKategori"
                                              id="exampleDataListKategori" :placeholder="$t('t-choose')" />
                                            <datalist id="datalistOptionsKategori">

                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-lg-12">
                                          <label for="aciklamaInput" class="form-label"> {{
                                              $t("t-subject")
                                          }}</label>
                                          <textarea class="form-control" id="exampleFormControlTextarea5"
                                            rows="2"></textarea>
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
            <!-- filtreleme olacak -->
            <div class="row g-3 ">
              <div class="col-xxl-2">
                    <div>
                      <label class="form-label"> {{ $t("t-code") }}</label>
                      <input
                        class="form-control form-control-sm"
                        list="datalistCodeDataBase"
                        id="exampleDataList"
                        :placeholder="$t('t-choose')"
                      />
                      <datalist id="datalistCodeDataBase"> </datalist>
                    </div>
                  </div>
                  <div class="col-xxl-2">
                    <div>
                      <label class="form-label"> {{ $t("t-category") }}</label>
                      <input
                        class="form-control form-control-sm"
                        list="datalistCategoryDataBase"
                        id="exampleDataList"
                        :placeholder="$t('t-choose')"
                      />
                      <datalist id="datalistCategoryDataBase"> </datalist>
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
                            <table style="width: 100% !important; margin-right: -200px;" id="myDataBaseTable"
                              class="listingTable table align-middle table-nowrap">
                              <thead class="table-light text-muted">
                                <tr>
                                  <th class="sort" scope="col">{{ $t("t-code") }}</th>
                                  <th class="sort" scope="col"> {{ $t("t-subject") }}
                                  </th>
                                  <th class="sort" scope="col">{{ $t("t-category") }}
                                  </th>
                                </tr>
                              </thead>
                              <tbody class="list form-check-all">
                                <tr v-for="dataBase in dataBases" :key="dataBase.id">
                                  <td>{{ dataBase.id }}</td>
                                  <td>{{ dataBase.title }}</td>
                                  <td>{{ dataBase.id }}</td>
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