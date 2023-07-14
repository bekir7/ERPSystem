<script>
import { defineAsyncComponent } from "vue";

const Layout = defineAsyncComponent(() => import("kurumsalbody/Layout"));
const PageHeader = defineAsyncComponent(() =>
  import("kurumsalbody/PageHeader")
);

import axios from "axios";
import appConfig from "@/../app.config";
import DataTable from "datatables.net-bs5";
import $ from "jquery";

export default {
  page: {
    title: "Envanter Yönetimi",
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
      title: this.$t("t-inventory-management"),
      items: [
        {
          text: this.$t("t-service-management"),
          href: "/",
        },
        {
          text: this.$t("t-inventory-management"),
          active: true,
        },
      ],
      myInventorys: [],
      inventoryLists: [],
      relatedInventoryLists: [],
      btInventoryLists: [],
    };
  },
  components: {
    Layout,
    PageHeader,
  },

  mounted() {
    setTimeout(() => {
      this.getMyInventory();
      this.getInventoryList();
      this.getRelatedInventoryList();
      this.getBtInventoryList();
    }, 100);
  },
  methods: {
    getMyInventory() {
      axios
        .get("https://jsonplaceholder.typicode.com/posts")
        .then(({ data }) => {
          this.myInventorys = data;
          this.$nextTick(() => {
            $("#myMyInventoryTable").DataTable({
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
    getInventoryList() {
      axios
        .get("https://jsonplaceholder.typicode.com/posts")
        .then(({ data }) => {
          this.inventoryLists = data;
          this.$nextTick(() => {
            $("#myInventoryListTable").DataTable({
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
    getRelatedInventoryList() {
      axios
        .get("https://jsonplaceholder.typicode.com/posts/1/comments")
        .then(({ data }) => {
          this.relatedInventoryLists = data;
          this.$nextTick(() => {
            $("#myRelatedInventoryListTable").DataTable({
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
    getBtInventoryList() {
      axios
        .get("https://jsonplaceholder.typicode.com/posts")
        .then(({ data }) => {
          this.btInventoryLists = data;
          this.$nextTick(() => {
            $("#myBtInventoryListTable").DataTable({
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
              data-bs-target="#newInventoryModalgrid"
            >
              <i class="ri-add-line label-icon align-middle fs-16 me-2"></i>
              {{ $t("t-new-inventory-record") }}
            </button>
            <br /><br />
            <!--modal -->
            <div
              class="modal zoomIn"
              id="newInventoryModalgrid"
              tabindex="-1"
              aria-labelledby="exampleModalgridLabel"
              aria-modal="true"
            >
              <div class="modal-dialog modal-xl">
                <div class="modal-content">
                  <div class="modal-header" style="background-color: #f1f1f1">
                    <h5 class="modal-title" id="exampleModalgridLabel">
                      {{ $t("t-inventory-detail") }}
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
                    <!-- ilk card -->
                    <div class="card">
                      <div class="card-header align-items-center d-flex">
                        <h4 class="card-title mb-0 flex-grow-1">
                          {{ $t("t-general-information") }}
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
                                              {{ $t("t-old-barcode") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                            />
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-category") }}</label
                                            >
                                            <input
                                              class="form-control form-control-sm"
                                              list="datalistOptionKate"
                                              id="exampleDataListOptionKate"
                                              :placeholder="$t('t-choose')"
                                            />
                                            <datalist id="datalistOptionKate">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-sub-category") }}</label
                                            >
                                            <input
                                              class="form-control form-control-sm"
                                              list="datalistOptionAltKate"
                                              id="exampleDataListOptionAltKate"
                                              :placeholder="$t('t-choose')"
                                            />
                                            <datalist
                                              id="datalistOptionAltKate"
                                            >
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{
                                                $t("t-responsible-group")
                                              }}</label
                                            >
                                            <input
                                              class="form-control form-control-sm"
                                              list="datalistOptionSGrup"
                                              id="exampleDataListOptionSGrup"
                                              :placeholder="$t('t-choose')"
                                            />
                                            <datalist id="datalistOptionSGrup">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-person-charge") }}</label
                                            >
                                            <input
                                              class="form-control form-control-sm"
                                              list="datalistOptionSKisi"
                                              id="exampleDataListOptionSKisi"
                                              :placeholder="$t('t-choose')"
                                            />
                                            <datalist id="datalistOptionSKisi">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-situation") }}</label
                                            >
                                            <input
                                              class="form-control form-control-sm"
                                              list="datalistOptionDurum"
                                              id="exampleDataListOptionDurum"
                                              :placeholder="$t('t-choose')"
                                            />
                                            <datalist id="datalistOptionDurum">
                                              <option
                                                :value="$t('t-project-phase')"
                                              ></option>
                                              <option
                                                :value="$t('t-scrap')"
                                              ></option>
                                              <option
                                                :value="$t('t-in-stock')"
                                              ></option>
                                              <option
                                                :value="$t('t-in-use')"
                                              ></option>
                                              <option
                                                :value="
                                                  $t('t-dropped-from-inventory')
                                                "
                                              ></option>
                                              <option
                                                :value="$t('t-in-care')"
                                              ></option>
                                              <option
                                                :value="$t('t-in-the-archive')"
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
                                              {{ $t("t-creation-date") }}</label
                                            >
                                            <input
                                              type="date"
                                              class="form-control form-control-sm"
                                            />
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-region") }}</label
                                            >
                                            <input
                                              class="form-control form-control-sm"
                                              list="datalistOptionRegion"
                                              id="exampleDataListOptionRegion"
                                              :placeholder="$t('t-choose')"
                                            />
                                            <datalist id="datalistOptionRegion">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-location") }}</label
                                            >
                                            <input
                                              class="form-control form-control-sm"
                                              list="datalistOptionLokasyon"
                                              id="exampleDataListOptionLokasyon"
                                              :placeholder="$t('t-choose')"
                                            />
                                            <datalist
                                              id="datalistOptionLokasyon"
                                            >
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              Platform</label
                                            >
                                            <input
                                              class="form-control form-control-sm"
                                              list="datalistOptionPlatform"
                                              id="exampleDataListOptionPlatform"
                                              :placeholder="$t('t-choose')"
                                            />
                                            <datalist
                                              id="datalistOptionPlatform"
                                            >
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-department") }}</label
                                            >
                                            <input
                                              class="form-control form-control-sm"
                                              list="datalistOptionDepart"
                                              id="exampleDataListOptionDepart"
                                              :placeholder="$t('t-choose')"
                                            />
                                            <datalist id="datalistOptionDepart">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-3">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-user") }}</label
                                            >
                                            <input
                                              class="form-control form-control-sm"
                                              list="datalistOptionUser"
                                              id="exampleDataListOptionUser"
                                              :placeholder="$t('t-choose')"
                                            />
                                            <datalist id="datalistOptionUser">
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-12">
                                          <label
                                            for="aciklamaInput"
                                            class="form-label"
                                          >
                                            {{ $t("t-explanation") }}
                                          </label>
                                          <textarea
                                            class="form-control"
                                            id="exampleFormControlTextarea5"
                                            rows="2"
                                          ></textarea>
                                        </div>
                                        <div class="col-xxl-6">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-entity-name") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                            />
                                          </div>
                                        </div>
                                        <div class="col-xxl-6">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{
                                                $t("t-associated-entity")
                                              }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                            />
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
                    <!-- liste -->
                    <div class="card">
                      <div class="card-header align-items-center d-flex">
                        <h4 class="card-title mb-0 flex-grow-1">
                          {{ $t("t-related-inventory-list") }}
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
                                      <!-- tablo -->
                                      <div class="card-body">
                                        <div
                                          class="tab-pane"
                                          id="nav-badge-damage"
                                          role="tabpanel"
                                        >
                                          <div class="d-flex">
                                            <div class="flex-grow-1 ms-2">
                                              <div class="row">
                                                <div class="card card-body">
                                                  <div class="card-body">
                                                    <div
                                                      class="table-responsive table-card"
                                                      style="
                                                        width: 100% !important;
                                                      "
                                                    >
                                                      <table
                                                        style="
                                                          width: 100% !important;
                                                          margin-right: -200px;
                                                        "
                                                        id="myRelatedInventoryListTable"
                                                        class="listingTable table align-middle table-nowrap"
                                                      >
                                                        <thead
                                                          class="table-light text-muted"
                                                        >
                                                          <tr>
                                                            <th
                                                              class="sort"
                                                              scope="col"
                                                            >
                                                              {{ $t("t-code") }}
                                                            </th>
                                                            <th
                                                              class="sort"
                                                              scope="col"
                                                            >
                                                              {{ $t("t-name") }}
                                                            </th>
                                                            <th
                                                              class="sort"
                                                              scope="col"
                                                            >
                                                              {{
                                                                $t("t-category")
                                                              }}
                                                            </th>
                                                            <th
                                                              class="sort"
                                                              scope="col"
                                                            >
                                                              {{
                                                                $t(
                                                                  "t-sub-category"
                                                                )
                                                              }}
                                                            </th>
                                                          </tr>
                                                        </thead>
                                                        <tbody
                                                          class="list form-check-all"
                                                        >
                                                          <tr
                                                            v-for="relatedInventoryList in relatedInventoryLists"
                                                            :key="
                                                              relatedInventoryList.id
                                                            "
                                                          >
                                                            <td>
                                                              {{
                                                                relatedInventoryList.id
                                                              }}
                                                            </td>
                                                            <td>
                                                              {{
                                                                relatedInventoryList.id
                                                              }}
                                                            </td>
                                                            <td>
                                                              {{
                                                                relatedInventoryList.id
                                                              }}
                                                            </td>
                                                            <td>
                                                              {{
                                                                relatedInventoryList.id
                                                              }}
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
                        <h4 class="card-title mb-0 flex-grow-1">
                          {{ $t("t-purchase-information") }}
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
                                        <div class="col-xxl-4">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{
                                                $t("t-purchase-information")
                                              }}</label
                                            >
                                            <input
                                              class="form-control form-control-sm"
                                              list="datalistOptionTedarik"
                                              id="exampleDataListOptionTedarik"
                                              :placeholder="$t('t-choose')"
                                            />
                                            <datalist
                                              id="datalistOptionTedarik"
                                            >
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-invoice-date") }}</label
                                            >
                                            <input
                                              type="date"
                                              class="form-control form-control-sm"
                                            />
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-bill-number-") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                            />
                                          </div>
                                        </div>
                                        <div class="col-xxl-6">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-unit-amount") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                            />
                                          </div>
                                        </div>
                                        <div class="col-xxl-6">
                                          <div>
                                            <label
                                              for="lastName"
                                              class="form-label"
                                              >{{
                                                $t("t-currency-unit")
                                              }}</label
                                            >
                                            <input
                                              class="form-control form-control-sm"
                                              list="datalistMoney"
                                              id="exampleDataListMoney"
                                              :placeholder="$t('t-choose')"
                                            />
                                            <datalist
                                              id="datalistMoney"
                                              style="width: 100px"
                                            >
                                              <option value="TL"></option>
                                              <option value="DOLAR"></option>
                                              <option value="EURO"></option>
                                            </datalist>
                                          </div>
                                        </div>
                                        <div class="col-xxl-4">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{
                                                $t("t-warranty-period")
                                              }}</label
                                            >
                                            &emsp;
                                            <input type="checkbox" />
                                          </div>
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

            <!-- Nav tabs -->
            <ul class="nav nav-tabs nav-justified mb-3" role="tablist">
              <li class="nav-item">
                <a
                  class="nav-link active"
                  data-bs-toggle="tab"
                  href="#nav-badge-inventory"
                  role="tab"
                  aria-selected="true"
                  style="font-size: 13px"
                >
                  {{ $t("t-my-inventory") }}
                  <span class="badge bg-success rounded-circle">5</span>
                </a>
              </li>
              <li class="nav-item">
                <a
                  class="nav-link"
                  data-bs-toggle="tab"
                  href="#nav-badge-inventory-list"
                  role="tab"
                  aria-selected="false"
                  style="font-size: 13px"
                >
                  {{ $t("t-inventory-list") }}
                  <span class="badge bg-primary rounded-circle">5</span>
                </a>
              </li>
              <li class="nav-item">
                <a
                  class="nav-link"
                  data-bs-toggle="tab"
                  href="#nav-badge-inventory-values"
                  role="tab"
                  aria-selected="false"
                  style="font-size: 13px"
                >
                  {{ $t("t-inventory-values") }}
                  <span class="badge bg-danger rounded-circle">5</span>
                </a>
              </li>
            </ul>

            <!-- Nav tabs -->
            <div class="tab-content text-muted">
              <div
                class="tab-pane active"
                id="nav-badge-inventory"
                role="tabpanel"
              >
                <!-- filtreleme olacak -->
                <div class="row g-3">
                  <div class="col-xxl-2">
                    <div>
                      <label class="form-label"> {{ $t("t-code") }}</label>
                      <input
                        class="form-control form-control-sm"
                        list="datalistCode"
                        id="exampleDataList"
                        :placeholder="$t('t-choose')"
                      />
                      <datalist id="datalistCode"> </datalist>
                    </div>
                  </div>
                  <div class="col-xxl-2">
                    <div>
                      <label class="form-label"> {{ $t("t-category") }}</label>
                      <input
                        class="form-control form-control-sm"
                        list="datalistCategory"
                        id="exampleDataList"
                        :placeholder="$t('t-choose')"
                      />
                      <datalist id="datalistCategory"> </datalist>
                    </div>
                  </div>
                  <div class="col-xxl-2">
                    <div>
                      <label class="form-label">
                        {{ $t("t-sub-category") }}</label
                      >
                      <input
                        class="form-control form-control-sm"
                        list="datalistSubCategory"
                        id="exampleDataList"
                        :placeholder="$t('t-choose')"
                      />
                      <datalist id="datalistSubCategory"> </datalist>
                    </div>
                  </div>
                </div>
                <div class="d-flex">
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
                                    id="myMyInventoryTable"
                                    class="listingTable table align-middle table-nowrap"
                                  >
                                    <thead class="table-light text-muted">
                                      <tr>
                                        <th class="sort" scope="col">
                                          {{ $t("t-code") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-entity-name") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-category") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-sub-category") }}
                                        </th>
                                      </tr>
                                    </thead>
                                    <tbody class="list form-check-all">
                                      <tr
                                        v-for="myInventory in myInventorys"
                                        :key="myInventory.id"
                                      >
                                        <td>{{ myInventory.id }}</td>
                                        <td>{{ myInventory.id }}</td>
                                        <td>{{ myInventory.id }}</td>
                                        <td>{{ myInventory.id }}</td>
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
                <div class="d-flex">
                  <div class="flex-shrink-0">
                    <i class="ri-checkbox-circle-fill text-success"></i>
                  </div>
                  <div class="flex-grow-1 ms-2">{{ $t("t-my-inventory") }}</div>
                </div>
              </div>

              <div
                class="tab-pane"
                id="nav-badge-inventory-list"
                role="tabpanel"
              >
                <!-- filtreleme olacak -->
                <div class="row g-3">
                  <div class="col-xxl-2">
                    <div>
                      <label class="form-label"> {{ $t("t-code") }}</label>
                      <input
                        class="form-control form-control-sm"
                        list="datalistCodeInventoryList"
                        id="exampleDataList"
                        :placeholder="$t('t-choose')"
                      />
                      <datalist id="datalistCodeInventoryList"> </datalist>
                    </div>
                  </div>

                  <div class="col-xxl-2">
                    <div>
                      <label class="form-label"> {{ $t("t-category") }}</label>
                      <input
                        class="form-control form-control-sm"
                        list="datalistCategoryInventoryList"
                        id="exampleDataList"
                        :placeholder="$t('t-choose')"
                      />
                      <datalist id="datalistCategoryInventoryList"> </datalist>
                    </div>
                  </div>
                  <div class="col-xxl-2">
                    <div>
                      <label class="form-label">
                        {{ $t("t-sub-category") }}</label
                      >
                      <input
                        class="form-control form-control-sm"
                        list="datalistSubCategoryInventoryList"
                        id="exampleDataList"
                        :placeholder="$t('t-choose')"
                      />
                      <datalist id="datalistSubCategoryInventoryList">
                      </datalist>
                    </div>
                  </div>
                  <div class="col-xxl-2">
                    <div>
                      <label class="form-label">
                        {{ $t("t-responsible-group") }}</label
                      >
                      <input
                        class="form-control form-control-sm"
                        list="datalistResponsibleInventoryList"
                        id="exampleDataList"
                        :placeholder="$t('t-choose')"
                      />
                      <datalist id="datalistResponsibleInventoryList">
                      </datalist>
                    </div>
                  </div>

                  <div class="col-xxl-2">
                    <div>
                      <label class="form-label">
                        {{ $t("t-person-charge") }}</label
                      >
                      <input
                        class="form-control form-control-sm"
                        list="datalistChargeInventoryList"
                        id="exampleDataList"
                        :placeholder="$t('t-choose')"
                      />
                      <datalist id="datalistChargeInventoryList"> </datalist>
                    </div>
                  </div>
                </div>
                <div class="d-flex">
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
                                    id="myInventoryListTable"
                                    class="listingTable table align-middle table-nowrap"
                                  >
                                    <thead class="table-light text-muted">
                                      <tr>
                                        <th class="sort" scope="col">
                                          {{ $t("t-code") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          Eski Barkod
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-category") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-sub-category") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-responsible-group") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-person-charge") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-situation") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-region") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-location") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-situation") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          Platform ID
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-department") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-entity-name") }}
                                        </th>
                                      </tr>
                                    </thead>
                                    <tbody class="list form-check-all">
                                      <tr
                                        v-for="inventoryList in inventoryLists"
                                        :key="inventoryList.id"
                                      >
                                        <td>{{ inventoryList.id }}</td>
                                        <td>{{ inventoryList.id }}</td>
                                        <td>{{ inventoryList.id }}</td>
                                        <td>{{ inventoryList.id }}</td>
                                        <td>{{ inventoryList.id }}</td>
                                        <td>{{ inventoryList.id }}</td>
                                        <td>{{ inventoryList.id }}</td>
                                        <td>{{ inventoryList.id }}</td>
                                        <td>{{ inventoryList.id }}</td>
                                        <td>{{ inventoryList.id }}</td>
                                        <td>{{ inventoryList.id }}</td>
                                        <td>{{ inventoryList.id }}</td>
                                        <td>{{ inventoryList.id }}</td>
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
                <div class="d-flex">
                  <div class="flex-shrink-0">
                    <i class="ri-checkbox-circle-fill text-success"></i>
                  </div>
                  <div class="flex-grow-1 ms-2">
                    {{ $t("t-inventory-list") }}
                  </div>
                </div>
              </div>

              <div
                class="tab-pane"
                id="nav-badge-inventory-values"
                role="tabpanel"
              >
                <!-- tablo -->
                <div class="d-flex">
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
                                    id="myBtInventoryListTable"
                                    class="listingTable table align-middle table-nowrap"
                                  >
                                    <!---->
                                    <!---->

                                    <thead class="table-light text-muted">
                                      <tr>
                                        <th class="sort" scope="col">
                                          {{ $t("t-code") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-category-name") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-entity-name") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-department") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-user") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-location") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-data-privacy-level") }}
                                        </th>

                                        <th class="sort" scope="col">
                                          {{ $t("t-accessibility") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-security") }}
                                        </th>
                                        <th class="sort" scope="col">
                                          {{ $t("t-integrity") }}
                                        </th>
                                      </tr>
                                    </thead>
                                    <tbody class="list form-check-all">
                                      <tr
                                        v-for="btInventoryList in btInventoryLists"
                                        :key="btInventoryList.id"
                                      >
                                        <td>{{ btInventoryList.id }}</td>
                                        <td>{{ btInventoryList.id }}</td>
                                        <td>{{ btInventoryList.id }}</td>
                                        <td>{{ btInventoryList.id }}</td>
                                        <td>{{ btInventoryList.id }}</td>
                                        <td>{{ btInventoryList.id }}</td>
                                        <td>{{ btInventoryList.id }}</td>
                                        <td>{{ btInventoryList.id }}</td>
                                        <td>{{ btInventoryList.id }}</td>
                                        <td>{{ btInventoryList.id }}</td>
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
                <div class="d-flex">
                  <div class="flex-shrink-0">
                    <i class="ri-checkbox-circle-fill text-success"></i>
                  </div>
                  <div class="flex-grow-1 ms-2">
                    {{ $t("t-inventory-values") }}
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
