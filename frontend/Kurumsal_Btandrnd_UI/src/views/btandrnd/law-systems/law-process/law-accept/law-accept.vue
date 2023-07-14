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
    title: "Dava isteği",
    meta: [
      {
        name: "requestDescription",
        content: appConfig.requestDescription,
      },
    ],
  },
  data() {
    return {
      Request:[],
      archiveId:null,
      clientName:null,
      clientStatus:null,
      caseStatus:null,
      date:null,
      courtType:null,
      caseType:null,
      city:null,
      county:null,
      court:null,
      basisNo:null,
      clientDocuments:null,
      counterpartyDocuments:null,
      authorityDocuments:null,
      type:null,
      counterpartyStatus:null,
      counterpartyName:null,
      tc:null,
      description:null,
      
      
      status:"Yönetici Bekleniyor",
      status2:"Onaylandı",
      status3:"Reddedildi",
      status4:"İade Edildi",

      status5:"Sipariş Alındı",
      status6:"Yolda",
      status7:"Kargo Şubesinde",
      status8:"Teslim Edildi",
      
      chooseOption: null,
      title: ("Dava isteği"),
      items: [
        {
          text: ("Dava Sistemi"),
          href: "/",
        },
        {
          text: ("Dava isteği"),
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
      this.created();
    
    }, 100);
  },
  methods: {
    onChange(event){
      this.durum=event.target.value;
      return this.durum;
    },

     //Gönder Buton
     addRequest () {
                   
                   var newRequest = {
                  
                  archiveId:this.archiveId,
                  clientName:this.clientName,
                  clientStatus:this.clientStatus,
                  caseStatus: this.caseStatus, 
                  date:this.date,
                  courtType:this.courtType,
                  caseType:this.caseType,
                  city:this.city,
                  county:this.county,
                  court:this.court,
                  basisNo:this.basisNo,
                  clientDocuments:this.clientDocuments,
                  counterpartyDocuments:this.counterpartyDocuments,
                  authorityDocuments:this.authorityDocuments,
                  type:this.type,
                  counterpartyStatus:this.counterpartyStatus,
                  counterpartyName:this.counterpartyName,
                  tc:this.tc,
                  description:this.description,
           }
                   axios.post("http://localhost:54558/api/law/create", newRequest)
                   .then(res => this.Request = res.data)
           },

created() {
      axios
        .get("http://localhost:54558/api/law")
        .then(({ data }) => {
          this.Request = data;
          this.$nextTick(() => {
            $("#myRequestTable").DataTable({
             
             
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
    <div class="row font" id="app">
      <div class="col-lg-12">
        <div class="card">
          <div class="card-body">
            <button
              type="button"
              class="btn btn-soft-dark waves-effect waves-light btn-sm"
              data-bs-toggle="modal"
              data-bs-target="#newAccessModalgrid"  

            >
            <i class="ri-add-line label-icon align-middle fs-16 me-2"></i>
              {{ ("Yeni Dava Ekle") }}<!--yeni erişim talebi-->
              <br /><br />
          </button>
         
           <!--Taleplerim modal -->
           <div
              class="modal zoomIn"
              id="newAccessModalgrid"
              tabindex="-1"
              aria-labelledby="exampleModalgridLabel"
              aria-modal="true"
            >
              <div class="modal-dialog modal-xl">
                <div class="modal-content">
                  <div class="modal-header" style="background-color: #f3aeae">
                    
                    <hr />
                    <div class="text-center">
                                <img src="@/assets/images/common/alisan-logo-normal.png" alt="" height="60" />
                      </div>
                    <button
                      type="button"
                      class="btn-close"
                      data-bs-dismiss="modal"
                      aria-label="Close"
                    ></button>
                  </div>
                  <div class="modal-body" style="background-color: #f3aeae">
                    <!-- ilk card -->
                    <div class="card">
                      <div class="card-header align-items-center d-flex">
                        <h4 class="card-title mb-0 flex-grow-1">
                          {{ $t("MÜVEKKİL VE DURUM BİLGİLERİ") }}
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
                                      <div class="row g-5">
                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{$t("Arşiv No") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="archiveId"
                                            />
                                          </div>
                                        </div>
                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{$t("Müvekkil") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="clientName"
                                            />
                                          </div>
                                        </div>

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Müvekkil Konumu : ") }}</label
                                            >
                                          
                                            
                                            <b-form-select v-model="clientStatus">
                                            <option disabled value="">Lütfen Seçiniz</option>
                                            <option>Davalı</option>
                                            <option>Davacı</option>
                                           
                                              </b-form-select>
                                           
                                          </div>
                                        </div>

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Dava Durumu : ") }}</label
                                            >
                                          
                                            
                                            <b-form-select v-model="caseStatus">
                                            <option disabled value="">Lütfen Seçiniz</option>
                                            <option>Devam Ediyor</option>
                                            <option>Reddedildi</option>
                                            <option>Kabul Edildi</option>
                                            <option>Kısmen Kabul\Reddedildi</option>
                                            <option>İstinafta</option>
                                            <option>Yargıtayda</option>
                                            <option>Müracaata Bırakıldı</option>
                                              </b-form-select>
                                           
                                          </div>
                                        </div>


                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("Başlama Tarihi") }}</label
                                            >
                                            <input
                                              type="date"
                                              class="form-control form-control-sm"
                                              v-model="date"
                                              id="dateInput"
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

                    <div class="card">
                      <div class="card-header align-items-center d-flex">
                        <h4 class="card-title mb-0 flex-grow-1">
                          {{ $t("DOSYA BİLGİLERİ") }}
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
                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Mahkeme Türü : ") }}</label
                                            >
                                          
                                            
                                            <b-form-select v-model="courtType">
                                            <option disabled value="">Lütfen Seçiniz</option>
                                            <option>Hukuk Mahkemeleri</option>
                                            <option>Asliye Hukuk Mahkemeleri</option>
                                            <option>Sulh Hukuk Mahkemeleri</option>
                                            <option>Uzmanlık Mahkemeleri</option>
                                            <option>Ticaret Mahkemeleri</option>
                                            <option> Aile Mahkemeleri</option>
                                            <option>Tüketici Mahkemeleri</option>
                                            <option>İcra Mahkemeleri</option>
                                            <option> İş Mahkemeleri</option>
                                            <option>Kadastro Mahkemeleri</option>
                                            <option>Fikri ve Sinai Hukuk Mahkemeleri</option>
                                            <option>Ağır Ceza Mahkemeleri</option>
                                            <option>Asliye Ceza Mahkemeleri</option>
                                            <option>Uzmanlık Ceza Mahkemeleri</option>
                                            <option>İdare Mahkemeleri</option>
                                            <option>Vergi Mahkemeleri</option>
                                            <option>Bölge İstinaf Mahkemeleri</option>
                                            <option>Asliye Ceza Mahkemeleri</option>
                                              </b-form-select>
                                           
                                          </div>
                                        </div>
                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Dava Türü : ") }}</label
                                            >
                                          
                                            
                                            <b-form-select v-model="caseType">
                                            <option disabled value="">Lütfen Seçiniz</option>
                                            <option>Edim Davaları</option>
                                            <option>Tespit Davaları</option>
                                            <option>Belirsiz Alacak Davası</option>
                                            <option>Terditli Davalar</option>
                                            <option>Seçimlik Davalar</option>
                                            <option> Kısmi Dava</option>
                                            <option>Mütelahik Davalar</option>
                                            <option>Topluluk Davaları</option>
                                              </b-form-select>
                                           
                                          </div>
                                        </div>
                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{$t("İl") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="city"
                                            />
                                          </div>
                                        </div>
                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{$t("İlçe") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="county"
                                            />
                                          </div>
                                        </div>
                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Mahkeme: ") }}</label
                                            >
                                          
                                            
                                            <b-form-select v-model="court">
                                            <option disabled value="">Lütfen Seçiniz</option>
                                            <option>1. Mahkeme</option>
                                            <option>2. Mahkeme</option>
                                            <option>3. Mahkeme</option>
                                            
                                              </b-form-select>
                                           
                                          </div>
                                        </div>
                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{$t("Esas No") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="basisNo"
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
                    <div class="card">
                      <div class="card-header align-items-center d-flex">
                        <h4 class="card-title mb-0 flex-grow-1">
                          {{ $t("KARŞI TARAF BİLGİLERİ") }}
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
                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Türü : ") }}</label
                                            >
                                          
                                            
                                            <b-form-select v-model="type">
                                            <option disabled value="">Lütfen Seçiniz</option>
                                            <option>Şahıs</option>
                                            <option>Şirket</option>
                                              </b-form-select>
                                           
                                          </div>
                                        </div>
                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Konumu : ") }}</label
                                            >
                                          
                                            
                                            <b-form-select v-model="counterpartyStatus">
                                            <option disabled value="">Lütfen Seçiniz</option>
                                            <option>Davalı</option>
                                            <option>Davacı</option>
                                              </b-form-select>
                                           
                                          </div>
                                        </div>
                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{$t("İsim") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="counterpartyName"
                                            />
                                          </div>
                                        </div>

                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{$t("TC/Vergi/Mersist") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="tc"
                                            />
                                          </div>
                                        </div>
                                        
                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{$t("Açıklama") }}</label
                                            >
                                            <input
                                          
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="description"
                                            />
                                          </div>
                                        </div>
                                        <div class="hstack gap-2 justify-content-end">
                                          <button type="button" id="degisiklikTalebiBtn" class="btn btn-danger" data-bs-dismiss="modal" 
                                           >
                                           {{ $t("t-close") }}
                                          </button>
                                          <button type="button" id="degisiklikTalebiBtn"  class="btn btn-success" @click="addRequest();">
                                            {{ $t("Gönder") }}
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

  <ul class="nav nav-tabs nav-justified mb-3" role="tablist">
      <li class="nav-item">
                <a class="nav-link active " data-bs-toggle="tab" href="#nav-badge-my-requests" role="tab"
                  aria-selected="true" style="font-size: 13px">
                  {{ $t("Dava Listesi") }}
                 
                </a>
              </li>
             
              
              
            </ul>

            
            <div class="tab-content text-muted">
              <div class="tab-pane active" id="nav-badge-my-requests" role="tabpanel">
                <!-- taleplerim tablo -->
                <div class="d-flex">
                  <div class="card-body">
                    <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
                      <div class="d-flex">
                        <div class="flex-grow-1 ms-2">
                          <div class="row">
                            <div class="card card-body">
                              <div class="card-body">
                                <div class=" table-responsive table-card" style="width: 100% !important" id="myRequestTable">
                                  <table  style="width: 100% !important; margin-right: -200px; " 
                                    class="listingTable table align-middle table-nowrap">
                                    <thead class="table-light text-muted">
                                      <tr>
                                        
                                       
                                        <th class="sort" scope="col" >{{ $t("Arşiv No") }}</th>
                                        <th class="sort" scope="col">{{ $t("Müvekkil") }}</th>
                                        <th class="sort" scope="col">{{ $t("Müvekkil Konumu") }}</th>
                                        <th class="sort" scope="col">{{ $t("Mahkeme Türü") }}</th>
                                        <th class="sort" scope="col">{{ $t("Dava Türü") }}</th>
                                      </tr>
                                    </thead>
                                    <tbody class="list form-check-all">
                                      <tr v-for="request in Request" :key="request.id">
                                        
                                        
                                        <td >{{request.archiveId  }}</td>
                                        <td>{{ request.clientName }}</td>
                                        <td>{{ request.clientStatus }}</td>
                                        <td>{{ request.courtType }}</td>
                                        <td>{{ request.caseType }}</td>
                                       
                                       
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
<style lang="scss" >

.green{
  background-color: green;
}
.text-right {
    text-align: right;
    margin-top: 0cm;
}

.text-left {
    text-align: left;
    margin-top: 0cm;
}

.main-contentt {
    min-height: 100vh;
    padding: 1rem;
    display: flex;
    justify-content: center;
    align-items: center;
    @media print {
        align-items: flex-start;
    }
}
.textarea {
    width: 100%;
    min-height: 1px;
}

#invoice-app {
    background-color: white;
    padding: 2rem;
    border-radius: 0.5rem;
}

.headerr {
    @media (min-width: 761px) {
        display: flex;
    }

div {
        &:nth-child(-n+1){
            @media (min-width: 761px) {
                order: 1;
                flex: 1;
                text-align: right;
                padding-left: 1rem;
            }
        }
    }
}








@import url("https://fonts.googleapis.com/css2?family=Nunito:wght@300;400;500;600;700&display=swap%22");

@font-face {
  font-family: "Nunito";
  src: url("https://fonts.googleapis.com/css2?family=Nunito:wght@300;400;500;600;700&display=swap%22");
}
.font {
  font-family: "Nunito", sans-serif;
}
</style>
