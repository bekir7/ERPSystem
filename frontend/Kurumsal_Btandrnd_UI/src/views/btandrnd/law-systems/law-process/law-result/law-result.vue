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
    title: "Duruşma isteği",
    meta: [
      {
        name: "requestDescription",
        content: appConfig.requestDescription,
      },
    ],
  },
  data() {
    return {
        Doc:[],
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
      result:null,
      result2:"Kazanıldı",
      result3:"Kaybedildi",
      
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
    editClick(request){
                this.archiveId=request.archiveId,
                this.description=request.description
                  
    },
    

created() {
      axios
        .get("http://localhost:54558/api/hukuksonuc")
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
           
         
           <!--Taleplerim modal -->
           <div
              class="modal zoomIn"
              id="requestDetail"
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
                        <h5 class="modal-title" id="exampleModalgridLabel">
                      {{ $t("Sonuç Detay") }}
                    </h5>
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
                                              {{ description  }} </label
                                            >
                                            <div class="hstack gap-2 justify-content-end">
                                          
                                          
  
                  

                                          
                                         
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
                                        
                                        
                                        <th class="sort" scope="col" >{{ ("Durum") }}</th>
                                        <th class="sort" scope="col" >{{ ("Dava Tarihi") }}</th>
                                        <th class="sort" scope="col" >{{ ("Arşiv No") }}</th>
                                        <th class="sort" scope="col" >{{ ("Müvekkil") }}</th>
                                        <th class="sort" scope="col">{{ ("Müvekkil Konumu") }}</th>
                                        <th class="sort" scope="col">{{ ("Karşı Taraf İsmi") }}</th>
                                        <th class="sort" scope="col">{{ ("Karşı Konumu") }}</th>
                                        <th class="sort" scope="col">{{ ("İl/İlçe") }}</th>
                                      </tr>
                                    </thead>
                                    <tbody class="list form-check-all">
                                      <tr v-for="request in Request" :key="request.id">
                                        
                                     
                                        <td >{{request.result  }}</td>
                                        <td>{{ request.date }}</td>
                                        <td>{{ request.archiveId }}</td>
                                        <td>{{ request.clientName }}</td>
                                        <td>{{ request.clientStatus }}</td>
                                        <td>{{ request.counterpartyName }}</td>
                                        <td>{{ request.counterpartyStatus }}</td>
                                        <td>{{ request.city }}/{{ request.county }}</td>
                                       
                                        <button
                                       
                                       type="button"
                                       class="btn btn-soft-dark waves-effect waves-light btn-sm"
                                       data-bs-toggle="modal"
                                       data-bs-target="#requestDetail"  
                                       @click="editClick(request)"
                                      
                                     >
                                    
                                       {{ $t("Sonuç Detayı") }}
                                       
                             
                                   </button>
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
