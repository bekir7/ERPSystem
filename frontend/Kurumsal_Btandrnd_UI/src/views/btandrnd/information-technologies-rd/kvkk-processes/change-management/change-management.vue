<script>
import { defineAsyncComponent } from "vue";

const Layout = defineAsyncComponent(() => import("kurumsalbody/Layout"));
const PageHeader = defineAsyncComponent(() =>
  import("kurumsalbody/PageHeader")
);

import $ from "jquery";
import axios from "axios";
import appConfig from "@/../app.config";
import DataTable from 'datatables.net-bs5';

export default {
  page: {
    title: "Değişiklik Yönetimi",
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
      title: this.$t("t-change-management"),
      items: [
        {
          text: this.$t("t-kvkk-processes"),
          href: "/",
        },
        {
          text: this.$t("t-change-management"),
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
      this.getChangeListing();
    }, 100);
  },
  methods: {
    getChangeListing() {
      axios
        .get("https://jsonplaceholder.typicode.com/posts")
        .then(({ data }) => {
          this.changeListings = data;
          this.$nextTick(() => {
            $("#myChangeListingTable").DataTable({
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
            <button
              type="button"
              class="btn btn-soft-dark waves-effect waves-light btn-sm"
              data-bs-toggle="modal"
              data-bs-target="#newChangeModalgrid"
            >
              <i class="ri-add-line label-icon align-middle fs-16 me-2"></i>
              {{ $t("t-new-change-request") }}
            </button>
            <br /><br />
            <!--modal -->
            <div
              class="modal zoomIn"
              id="newChangeModalgrid"
              tabindex="-1"
              aria-labelledby="exampleModalgridLabel"
              aria-modal="true"
            >
              <div class="modal-dialog modal-xl">
                <div class="modal-content">
                  <div class="modal-header" style="background-color: #f1f1f1">
                    <h5 class="modal-title" id="exampleModalgridLabel">
                      {{ $t("t-new-change-request") }}
                    </h5>
                    <hr />
                    <button
                      type="button"
                      class="btn-close"
                      data-bs-dismiss="modal"
                      aria-label="Close"
                    ></button>
                  </div>
                  <div class="modal-body" style="background-color: #f1f1f1">
                    <div class="card">
                      <div class="card-header align-items-center d-flex">
                        <h4 class="card-title mb-0 flex-grow-1">
                          {{ $t("t-change-information") }}
                        </h4>
                      </div>
                      <div class="card-body">
                        <div
                          class="tab-pane"
                          id="nav-badge-damage"
                          role="tabpanel"
                        >
                          <div class="d-flex">
                            <div class="flex-grow-1 ms-2">
                              <div class="row">
                                <div class="card-body">
                                  <div
                                    class="table-responsive table-card"
                                    style="width: 100% !important"
                                  >
                                    <div class="card-body">
                                      <div class="row g-3">
                                        <div class="col-xxl-3">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{
                                                $t("t-requesting-change")
                                              }}</label
                                            >
                                            <input
                                              class="form-control form-control-sm"
                                              list="datalistOptionsTalep"
                                              id="exampleDataListTalep"
                                              :placeholder="$t('t-choose')"
                                            />
                                            <datalist id="datalistOptionsTalep">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-reason-change") }}</label
                                            >
                                            <input
                                              class="form-control form-control-sm"
                                              list="datalistOptionsSebep"
                                              id="exampleDataListSebep"
                                              :placeholder="$t('t-choose')"
                                            />
                                            <datalist id="datalistOptionsSebep">
                                              <option
                                                :value="
                                                  $t('t-configuration-change')
                                                "
                                              ></option>
                                              <option
                                                :value="$t('t-go-live')"
                                              ></option>
                                              <option
                                                :value="$t('t-put-use')"
                                              ></option>
                                              <option
                                                :value="$t('t-care')"
                                              ></option>
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-date-change") }}</label
                                            >
                                            <input
                                              type="date"
                                              class="form-control form-control-sm"
                                              id="dateInput"
                                            />
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{
                                                $t("t-associated-inventory")
                                              }}</label
                                            >
                                            <input
                                              class="form-control form-control-sm"
                                              list="datalistOptionsİliskili"
                                              id="exampleDataListİliskili"
                                              :placeholder="$t('t-choose')"
                                            />
                                            <datalist
                                              id="datalistOptionsİliskili"
                                            >
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-lg-6">
                                          <label
                                            for="aciklamaInput"
                                            class="form-label"
                                          >
                                            {{ $t("t-subject") }}</label
                                          >
                                          <textarea
                                            class="form-control"
                                            id="exampleFormControlTextarea5"
                                            rows="2"
                                          ></textarea>
                                        </div>
                                        <div class="col-lg-6">
                                          <label
                                            for="aciklamaInput"
                                            class="form-label"
                                            >{{ $t("t-reason-change") }}</label
                                          >
                                          <textarea
                                            class="form-control"
                                            id="exampleFormControlTextarea5"
                                            rows="2"
                                          ></textarea>
                                        </div>
                                        <div class="col-lg-6">
                                          <label
                                            for="aciklamaInput"
                                            class="form-label"
                                            >{{ $t("t-risks-live") }}</label
                                          >
                                          <textarea
                                            class="form-control"
                                            id="exampleFormControlTextarea5"
                                            rows="2"
                                          ></textarea>
                                        </div>
                                        <div class="col-lg-6">
                                          <label
                                            for="aciklamaInput"
                                            class="form-label"
                                            >{{
                                              $t("t-description-done")
                                            }}</label
                                          >
                                          <textarea
                                            class="form-control"
                                            id="exampleFormControlTextarea5"
                                            rows="2"
                                          ></textarea>
                                        </div>
                                        <div class="col-lg-12">
                                          <label
                                            for="aciklamaInput"
                                            class="form-label"
                                            >{{
                                              $t(
                                                "t-departments-affected-change"
                                              )
                                            }}</label
                                          >
                                          <textarea
                                            class="form-control"
                                            id="exampleFormControlTextarea5"
                                            rows="1"
                                          ></textarea>
                                        </div>
                                        <div
                                          class="hstack gap-2 justify-content-end"
                                        >
                                          <button
                                            type="button"
                                            class="btn btn-light"
                                            data-bs-dismiss="modal"
                                            id="degisiklikTalebiBtn"
                                          >
                                            {{ $t("t-close") }}
                                          </button>
                                          <button
                                            type="submit"
                                            class="btn btn-primary"
                                            id="degisiklikTalebiBtn"
                                          >
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
                          <div
                            class="table-responsive table-card"
                            style="width: 100% !important"
                          >
                            <table
                              style="
                                width: 100% !important;
                                margin-right: -200px;
                              "
                              id="myChangeListingTable"
                              class="listingTable table align-middle table-nowrap"
                            >
                              <thead class="table-light text-muted">
                                <tr>
                                  <th class="sort" scope="col">
                                    {{ $t("t-code") }}
                                  </th>
                                  <th class="sort" scope="col">
                                    {{ $t("t-subject") }}
                                  </th>
                                  <th class="sort" scope="col">
                                    {{ $t("t-associated-inventory") }}
                                  </th>
                                  <th class="sort" scope="col">
                                    {{ $t("t-requesting") }}
                                  </th>
                                </tr>
                              </thead>
                              <tbody class="list form-check-all">
                                <tr
                                  v-for="changeListing in changeListings"
                                  :key="changeListing.id"
                                >
                                  <td>{{ changeListing.id }}</td>
                                  <td>{{ changeListing.title }}</td>
                                  <td>{{ changeListing.id }}</td>
                                  <td>{{ changeListing.id }}</td>
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
