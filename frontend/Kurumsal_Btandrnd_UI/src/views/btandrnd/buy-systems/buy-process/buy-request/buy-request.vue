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
    title: "Satın Alma İsteği",
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
      RequestFatura:[],
      RequestYonetici:[],
      RequestSiparis:[],
      RequestKargo:[],
      RequestKargoYonetici:[],
      
      requestPieces:0,
      requestDate:null,
      requestor:null,
      requestPaymentType:null,
      requestSupplier:null,
      requestDepot:null,
      requestrequestCategory:null,
      requestMaterial:null,
      requestDescription:null,
      requestNo:0,
      descriptionDeny:null,
      descriptionDeny2:null,
      status:"Yönetici Bekleniyor",
      status2:"Onaylandı",
      status3:"Reddedildi",
      status4:"İade Edildi",

      status5:"Sipariş Alındı",
      status6:"Yolda",
      status7:"Kargo Şubesinde",
      status8:"Teslim Edildi",
      
      chooseOption: null,
      title: ("Satın Alma İsteği"),
      items: [
        {
          text: ("Satın Alma Sistemi"),
          href: "/",
        },
        {
          text: ("Satın Alma İsteği"),
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
      this.createdFatura();
      this.createdYonetici();
      this.createdSiparis();
      this.createdKargo();
      this.createdKargoYonetici();
      this.nowdatee();
    }, 100);
  },
  methods: {
    onChange(event){
      this.durum=event.target.value;
      return this.durum;
    },

Toplam(){
  this.toplam=this.requestPieces*10;
     return this.toplam;
},
Kdv(){
  this.kdv=this.toplam*18/100;
     return this.kdv;
},
Toplamtutar(){
  this.toptut=this.toplam+this.kdv;
  return this.toptut;
},
printscreen(){
  window.print();
},
nowdatee(){
      this.nowdate=new Date().toJSON().slice(0,10).replace(/-/g,'/');
      return this.nowdate;
    },
     //Gönder Buton
     addRequest () {
                   
                   var newRequest = {
                  
                   status:this.status,
                   requestNo:this.requestNo,
                   requestDate:this.requestDate,
                   requestor: this.requestor, 
                   requestCategory:this.requestCategory,
                   requestDepot:this.requestDepot,
                   requestSupplier:this.requestSupplier,
                   requestMaterial:this.requestMaterial,
                   requestPaymentType:this.requestPaymentType,
                   requestPieces:this.requestPieces,
                   requestDescription:this.requestDescription
           }
                   axios.post("http://localhost:54558/api/request/create", newRequest)
                   .then(res => this.Request = res.data)
           },
           addRequestFatura () {
                   
                   var newRequest = {
                  
                  
                   requestNo:this.requestNo,
                   requestDate:this.requestDate,
                   requestor: this.requestor, 
                   requestCategory:this.requestCategory,
                   requestDepot:this.requestDepot,
                   requestSupplier:this.requestSupplier,
                   requestMaterial:this.requestMaterial,
                   requestPaymentType:this.requestPaymentType,
                   requestPieces:this.requestPieces,
                   requestDescription:this.requestDescription
           }
                   axios.post("http://localhost:54558/api/faturarequest/createfatura", newRequest)
                   .then(res => this.RequestFatura = res.data)
           },
           addRequestYonetici () {
                   
                   var newRequest = {
                  
                  status:this.status,
                   requestNo:this.requestNo,
                   requestDate:this.requestDate,
                   requestor: this.requestor, 
                   requestCategory:this.requestCategory,
                   requestDepot:this.requestDepot,
                   requestSupplier:this.requestSupplier,
                   requestMaterial:this.requestMaterial,
                   requestPaymentType:this.requestPaymentType,
                   requestPieces:this.requestPieces,
                   requestDescription:this.requestDescription
           }
                   axios.post("http://localhost:54558/api/yoneticirequest/createyonetici", newRequest)
                   .then(res => this.RequestYonetici = res.data)
           },
           addRequestSiparis () {
                   
                   var newRequest = {
                  
                  
                   requestNo:this.requestNo,
                   requestDate:this.requestDate,
                   requestor: this.requestor, 
                   requestCategory:this.requestCategory,
                   requestDepot:this.requestDepot,
                   requestSupplier:this.requestSupplier,
                   requestMaterial:this.requestMaterial,
                   requestPaymentType:this.requestPaymentType,
                   requestPieces:this.requestPieces,
                   requestDescription:this.requestDescription
           }
                   axios.post("http://localhost:54558/api/siparisrequest/createsiparis", newRequest)
                   .then(res => this.RequestSiparis= res.data)
           },

           addRequestKargo () {
                   
                   var newRequest = {
                  
                   status5:this.status5,
                   requestNo:this.requestNo,
                   requestDate:this.requestDate,
                   requestor: this.requestor, 
                   requestCategory:this.requestCategory,
                   requestDepot:this.requestDepot,
                   requestSupplier:this.requestSupplier,
                   requestMaterial:this.requestMaterial,
                   requestPaymentType:this.requestPaymentType,
                   requestPieces:this.requestPieces,
                   requestDescription:this.requestDescription
           }
                   axios.post("http://localhost:54558/api/kargorequest/createkargo", newRequest)
                   .then(res => this.RequestKargo= res.data)
           },

           addRequestKargoYonetici () {
                   
                   var newRequest = {
                  
                    status5:this.status5,
                   requestNo:this.requestNo,
                   requestDate:this.requestDate,
                   requestor: this.requestor, 
                   requestCategory:this.requestCategory,
                   requestDepot:this.requestDepot,
                   requestSupplier:this.requestSupplier,
                   requestMaterial:this.requestMaterial,
                   requestPaymentType:this.requestPaymentType,
                   requestPieces:this.requestPieces,
                   requestDescription:this.requestDescription
           }
                   axios.post("http://localhost:54558/api/kargoyonetici/createkargoyonetici", newRequest)
                   .then(res => this.RequestKargoYonetici= res.data)
           },
//Yönetici Bekleniyor Yazdırıyoruz
           Status(){
 var newStatus={
  
                   status:this.status1,
                   requestNo:this.requestNo,
                   requestDate:this.requestDate,
                   requestor: this.requestor, 
                   requestCategory:this.requestCategory,
                   requestDepot:this.requestDepot,
                   requestSupplier:this.requestSupplier,
                   requestMaterial:this.requestMaterial,
                   requestPaymentType:this.requestPaymentType,
                   requestPieces:this.requestPieces,
                   requestDescription:this.requestDescription
  }
  axios.post("http://localhost:54558/api/request/update2", newStatus)
                        .then(res => this.Request = res.data)
                        .catch(err => console.log(err))
},
//Reddedildi Yazdırıyoruz
Status2(){
 var newStatus={
  descriptionDeny:this.descriptionDeny,
                   status:this.status3,
                   requestNo:this.requestNo,
                   requestDate:this.requestDate,
                   requestor: this.requestor, 
                   requestCategory:this.requestCategory,
                   requestDepot:this.requestDepot,
                   requestSupplier:this.requestSupplier,
                   requestMaterial:this.requestMaterial,
                   requestPaymentType:this.requestPaymentType,
                   requestPieces:this.requestPieces,
                   requestDescription:this.requestDescription
  }
  axios.post("http://localhost:54558/api/request/update2", newStatus)
                        .then(res => this.Request = res.data)
                        .catch(err => console.log(err))
},
//Onaylandı
Status3(){
 var newStatus={
  
                   status:this.status2,
                   requestNo:this.requestNo,
                   requestDate:this.requestDate,
                   requestor: this.requestor, 
                   requestCategory:this.requestCategory,
                   requestDepot:this.requestDepot,
                   requestSupplier:this.requestSupplier,
                   requestMaterial:this.requestMaterial,
                   requestPaymentType:this.requestPaymentType,
                   requestPieces:this.requestPieces,
                   requestDescription:this.requestDescription
  }
  axios.post("http://localhost:54558/api/request/update2", newStatus)
                        .then(res => this.Request = res.data)
                        .catch(err => console.log(err))
},
//iade edildi
Status4(){
 var newStatus={
  descriptionDeny2:this.descriptionDeny2,
                   status:this.status4,
                   requestNo:this.requestNo,
                   requestDate:this.requestDate,
                   requestor: this.requestor, 
                   requestCategory:this.requestCategory,
                   requestDepot:this.requestDepot,
                   requestSupplier:this.requestSupplier,
                   requestMaterial:this.requestMaterial,
                   requestPaymentType:this.requestPaymentType,
                   requestPieces:this.requestPieces,
                   requestDescription:this.requestDescription
  }
  axios.post("http://localhost:54558/api/request/update3", newStatus)
                        .then(res => this.Request = res.data)
                        .catch(err => console.log(err))
},
//Sipariş Alındı
Status5(){
 var newStatus={
  
                   status:this.status5,
                   requestNo:this.requestNo,
                   requestDate:this.requestDate,
                   requestor: this.requestor, 
                   requestCategory:this.requestCategory,
                   requestDepot:this.requestDepot,
                   requestSupplier:this.requestSupplier,
                   requestMaterial:this.requestMaterial,
                   requestPaymentType:this.requestPaymentType,
                   requestPieces:this.requestPieces,
                   requestDescription:this.requestDescription
  }
  axios.post("http://localhost:54558/api/kargorequest/update4", newStatus)
                        .then(res => this.RequestKargo = res.data)
                        .catch(err => console.log(err))
},
//Yolda
Status6(){
 var newStatus={
  
                   status:this.status6,
                   requestNo:this.requestNo,
                   requestDate:this.requestDate,
                   requestor: this.requestor, 
                   requestCategory:this.requestCategory,
                   requestDepot:this.requestDepot,
                   requestSupplier:this.requestSupplier,
                   requestMaterial:this.requestMaterial,
                   requestPaymentType:this.requestPaymentType,
                   requestPieces:this.requestPieces,
                   requestDescription:this.requestDescription
  }
  axios.post("http://localhost:54558/api/kargorequest/update4", newStatus)
                        .then(res => this.RequestKargo = res.data)
                        .catch(err => console.log(err))
},
//Şubede
Status7(){
 var newStatus={
  
                   status:this.status7,
                   requestNo:this.requestNo,
                   requestDate:this.requestDate,
                   requestor: this.requestor, 
                   requestCategory:this.requestCategory,
                   requestDepot:this.requestDepot,
                   requestSupplier:this.requestSupplier,
                   requestMaterial:this.requestMaterial,
                   requestPaymentType:this.requestPaymentType,
                   requestPieces:this.requestPieces,
                   requestDescription:this.requestDescription
  }
  axios.post("http://localhost:54558/api/kargorequest/update4", newStatus)
                        .then(res => this.RequestKargo = res.data)
                        .catch(err => console.log(err))
},
//Teslim Edildi
Status8(){
 var newStatus={
  
                   status:this.status8,
                   requestNo:this.requestNo,
                   requestDate:this.requestDate,
                   requestor: this.requestor, 
                   requestCategory:this.requestCategory,
                   requestDepot:this.requestDepot,
                   requestSupplier:this.requestSupplier,
                   requestMaterial:this.requestMaterial,
                   requestPaymentType:this.requestPaymentType,
                   requestPieces:this.requestPieces,
                   requestDescription:this.requestDescription
  }
  axios.post("http://localhost:54558/api/kargorequest/update4", newStatus)
                        .then(res => this.RequestKargo = res.data)
                        .catch(err => console.log(err))
},
           created() {
      axios
        .get("http://localhost:54558/api/request")
        .then(({ data }) => {
          this.Request = data;
          this.$nextTick(() => {
            $("#myRequestTable").DataTable({
             
             
            });
          });
        })
        .catch((error) => console.log(error.data));
    },

    createdFatura() {
      axios
        .get("http://localhost:54558/api/faturarequest")
        .then(({ data }) => {
          this.RequestFatura = data;
          this.$nextTick(() => {
            $("#myFaturaRequestTable").DataTable({
             
             
            });
          });
        })
        .catch((error) => console.log(error.data));
    },

    createdYonetici() {
      axios
        .get("http://localhost:54558/api/yoneticirequest")
        .then(({ data }) => {
          this.RequestYonetici = data;
          this.$nextTick(() => {
            $("#myYoneticiRequestTable").DataTable({
             
             
            });
          });
        })
        .catch((error) => console.log(error.data));
    },

    createdSiparis() {
      axios
        .get("http://localhost:54558/api/siparisrequest")
        .then(({ data }) => {
          this.RequestSiparis = data;
          this.$nextTick(() => {
            $("#mySiparisRequestTable").DataTable({
             
             
            });
          });
        })
        .catch((error) => console.log(error.data));
    },

    createdKargo() {
      axios
        .get("http://localhost:54558/api/kargorequest")
        .then(({ data }) => {
          this.RequestKargo = data;
          this.$nextTick(() => {
            $("#myKargoRequestTable").DataTable({
             
             
            });
          });
        })
        .catch((error) => console.log(error.data));
    },

    createdKargoYonetici() {
      axios
        .get("http://localhost:54558/api/kargoyonetici")
        .then(({ data }) => {
          this.RequestKargoYonetici = data;
          this.$nextTick(() => {
            $("#myKargoYoneticiTable").DataTable({
             
             
            });
          });
        })
        .catch((error) => console.log(error.data));
    },

    deleteRequest2 (id) {
          axios.delete("http://localhost:54558/api/yoneticirequest/delete/"+id)
                        .then(res => this.RequestYonetici = res.data)
                        .catch(err => console.log(err))
  },
  deleteRequest3 (id) {
          axios.delete("http://localhost:54558/api/siparisrequest/delete/"+id)
                        .then(res => this.RequestSiparis = res.data)
                        .catch(err => console.log(err))
  },
     /*Bt Onay Detay Butonundaki veriler*/ 
     editClick(request){
                   this.status=request.status,
                   this.requestNo=request.requestNo,
                   this.requestDate=request.requestDate,
                   this.requestor= request.requestor, 
                   this.requestCategory=request.requestCategory,
                   this.requestDepot=request.requestDepot,
                   this.requestSupplier=request.requestSupplier,
                   this.requestMaterial=request.requestMaterial,
                   this.requestPaymentType=request.requestPaymentType,
                   this.requestPieces=request.requestPieces,
                   this.requestDescription=request.requestDescription
    },
    editClick2(request){
this.descriptionDeny=request.descriptionDeny,
this.descriptionDeny2=request.descriptionDeny2
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
              {{ ("Satın Alma Talebi") }}<!--yeni erişim talebi-->
              <br /><br />
          </button>
         
            <!--Yonetici onay-->
            <div
              class="modal zoomIn"
              id="BtAdminDetail"
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
                      {{ $t("t-access-request") }}
                    </h5>
                      </div>
                      <div class="card-body">
                        <div
                          class="tab-pane" id="nav-badge-damage" role="tabpanel" >
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
                                              {{ $t("t-it-has-request")  }}:  </label
                                            >
                                            <label>
                                              {{requestor}}
                                            </label>
                                          </div>
                                        </div>
                                        
                                        
                                          <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("Talep Tarihi") }}:  </label
                                            >
                                           <label>
                                            {{ requestDate }}
                                           </label>
                                          </div>
                                        </div>

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Kategori : ") }}</label
                                            >
                                          
                                            
                                           <label>
                                            {{ requestCategory }}
                                           </label>
                                           
                                          </div>
                                        </div>
                                        

                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Depo : ") }}</label
                                            >
                                           <label>
                                            {{ requestDepot }}
                                           </label>
                                          </div>
                                        </div>
                                        

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Tedarikçi Firma: ") }}</label
                                            >
                                          
                                            
                                           <label>
                                            {{ requestSupplier }}
                                           </label>
                                           
                                          </div>
                                        </div>

                                        <div id="acompany" class="col-xxl-5" >
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Malzeme: ") }}</label
                                            >
                                          
                                            
                                          <label>
                                            {{ requestMaterial }}
                                          </label>

                                           
                                          </div>
                                        </div>

                                       

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Ödeme Şekli: ") }}</label
                                            >
                                          
                                            
                                           <label>
                                            {{ requestPaymentType }}
                                           </label>
                                           
                                          </div>
                                        </div>

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Adet: ") }}</label
                                            >
                                          
                                            
                                           <label>
                                            {{ requestPieces }}
                                           </label>
                                            
                                           
                                          </div>
                                        </div>

                                        


                                        
                                        <div class="col-xxl-10">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("Açıklama") }}: </label
                                            >
                                            <label>
                                              {{ requestDescription }}
                                            </label>
                                          </div>
                                        </div>
                                        <div class="hstack gap-2 justify-content-end">
                                          <b-button data-bs-toggle="modal" data-bs-target="#AdminRefuse"  variant="danger" > {{ "Reddet" }}
                                          </b-button>
                                          
  
                  <!--PopUp-->
                    <div>
                                          <b-modal
                                            hide-footer
                                            id="AdminRefuse"
                                            ref="modal"
                                            title="Reddetme Nedeni"
                                            
                                               >
                                               
                                        <form ref="form" >
                                        <b-form-group
                                            label="Red Nedeni"
                                            label-for="deny-input"
                                                 >
                                         <b-form-input
                                         id="deny-input"
                                         v-model="descriptionDeny"
                                         
            
                                             > 
                                            
                                               </b-form-input>
                                               <b-button @click="deleteRequest2(requestNo); Status2(); "> 
                                                        {{ "Reddet" }}

                                               </b-button>
                                              </b-form-group>
                                            </form>
                                          </b-modal>
                                        </div>

                                          <b-button data-bs-toggle="table" data-bs-target="#nav-badge-fatura" variant="success" @click="addRequestFatura(); addRequestKargo(); addRequestKargoYonetici(); deleteRequest2(requestNo); Status3();" > {{ "Onay" }}</b-button>
                                         
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

<!--Reddetme Nedeni Request Tabledaki-->
            <div
                                     class="modal zoomIn"
                                     id="requestDetail"
                                      tabindex="-1"
                                      aria-labelledby="exampleModalgridLabel"
                                      aria-modal="true"
                                     >
                                     <div class="modal-dialog modal-xl">
                                      <div class="modal-content">
                                        <div class="modal-body" style="background-color: #f3aeae">
                                           
                     <div class="card" >
                      <div class="card-header align-items-center d-flex">
                        
                      </div>
                      <div class="card-body">
                        <div class="tab-pane" id="nav-badge-damage" role="tabpanel" >
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
                                              {{ "Red Nedeni" }} : </label
                                            >
                                            
                                            <label 
                                            >
                                              {{descriptionDeny }}
                                            </label>
                                            
                                            
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




<!--Stok-->
<div
              class="modal zoomIn"
              id="SiparisDetail"
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
                      {{ $t("t-access-request") }}
                    </h5>
                      </div>
                      <div class="card-body">
                        <div
                          class="tab-pane" id="nav-badge-damage" role="tabpanel" >
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
                                              {{ $t("t-it-has-request")  }}:  </label
                                            >
                                            <label>
                                              {{requestor}}
                                            </label>
                                          </div>
                                        </div>
                                        
                                        
                                          <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("Talep Tarihi") }}:  </label
                                            >
                                           <label>
                                            {{ requestDate }}
                                           </label>
                                          </div>
                                        </div>

                                      
                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Kategori : ") }}</label
                                            >
                                          
                                            
                                           <label>
                                            {{ requestCategory }}
                                           </label>
                                           
                                          </div>
                                        </div>
                                        

                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Depo : ") }}</label
                                            >
                                           <label>
                                            {{ requestDepot }}
                                           </label>
                                          </div>
                                        </div>
                                        

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Tedarikçi Firma: ") }}</label
                                            >
                                          
                                            
                                           <label>
                                            {{ requestSupplier }}
                                           </label>
                                           
                                          </div>
                                        </div>

                                        <div id="acompany" class="col-xxl-5" >
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Malzeme: ") }}</label
                                            >
                                          
                                            
                                          <label>
                                            {{ requestMaterial }}
                                          </label>

                                           
                                          </div>
                                        </div>

                                       

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Ödeme Şekli: ") }}</label
                                            >
                                          
                                            
                                           <label>
                                            {{ requestPaymentType }}
                                           </label>
                                           
                                          </div>
                                        </div>

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Adet: ") }}</label
                                            >
                                          
                                            
                                           <label>
                                            {{ requestPieces }}
                                           </label>
                                            
                                           
                                          </div>
                                        </div>
                                        


                                        
                                        <div class="col-xxl-10">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-it-requestDescription") }}: </label
                                            >
                                            <label>
                                              {{ requestDescription }}
                                            </label>
                                          </div>
                                        </div>
                                        <div class="hstack gap-2 justify-content-end">
                                          <b-button data-bs-toggle="modal" data-bs-target="#StokRefuse"  variant="danger" > {{ "İade Et" }}
                                          </b-button>
                                          
  
                  <!--PopUp-->
                    <div>
                                          <b-modal
                                            hide-footer
                                            id="StokRefuse"
                                            ref="modal"
                                            title="Reddetme Nedeni"
                                            
                                               >
                                               
                                        <form ref="form" >
                                        <b-form-group
                                            label="Red Nedeni"
                                            label-for="deny-input"
                                                 >
                                         <b-form-input
                                         id="deny-input"
                                         v-model="descriptionDeny2"
                                         
            
                                             > 
                                            
                                               </b-form-input>
                                               <b-button @click="deleteRequest3(requestNo); Status4(); "> 
                                                        {{ "İade Et" }}

                                               </b-button>
                                              </b-form-group>
                                            </form>
                                          </b-modal>
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
                        <h5 class="modal-title" id="exampleModalgridLabel">
                      {{ ("Satın Alma Talebi") }}
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
                                              {{$t("Talep No") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="requestNo"
                                            />
                                          </div>
                                        </div>
                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{$t("t-it-has-request") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="requestor"
                                            />
                                          </div>
                                        </div>

                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-it-request-date") }}</label
                                            >
                                            <input
                                              type="date"
                                              class="form-control form-control-sm"
                                              v-model="requestDate"
                                              id="dateInput"
                                            />
                                          </div>
                                        </div>

                                      
                                        
                                        
                                          <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Kategori : ") }}</label
                                            >
                                          
                                            
                                            <b-form-select v-model="requestCategory" variant="underlined">
                                            <option disabled value="">Lütfen Seçiniz</option>
                                            <option>Elektronik</option>
                                            <option>Yedek Parça</option>
                                            <option>C</option>
                                              </b-form-select>
                                           
                                          </div>
                                        </div>
                                        

                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Depo : ") }}</label
                                            >
                                            <b-form-select v-model="requestDepot">
                                            <option disabled value="">Lütfen Seçiniz</option>
                                            <option>Bilgi İşlem</option>
                                            <option>AR-GE</option>
                                            <option>İnsan Kaynakları</option>
                                            <option>Üretim</option>
                                            <option>Muhasebe</option>
                                            <option>Finans</option>
                                              </b-form-select>
                                          </div>
                                        </div>
                                        

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Tedarikçi Firma: ") }}</label
                                            >
                                          
                                            
                                            <b-form-select v-model="requestSupplier" @change="onChange($event)" >
                                                <option value="" disabled selected>Choose Company</option>
                                              <option value="A şirketi">A şirketi</option>
                                              <option value="B şirketi">B şirketi</option>
                                                        </b-form-select>
                                           
                                          </div>
                                        </div>

                                        <div id="acompany" class="col-xxl-5" >
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Malzeme: ") }}</label
                                            >
                                          
                                            
                                            <b-form-select v-if="durum==='A şirketi'" v-model="requestMaterial">
                                                  <option value="" disabled selected>Choose Metarial</option>
                                                  <option >a1</option>
                                                  <option >a2</option>
                                                </b-form-select>

                                                <b-form-select v-if="durum==='B şirketi'" v-model="requestMaterial">
                                                  <option value="" disabled selected>Choose Metarial</option>
                                                  <option >b1</option>
                                                  <option >b2</option>
                                                </b-form-select>
                                               

                                           
                                          </div>
                                        </div>

                                       

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Ödeme Şekli: ") }}</label
                                            >
                                          
                                            
                                            <b-form-select v-model="requestPaymentType">
                                            <option disabled value="">Lütfen Seçiniz</option>
                                            <option>Peşin</option>
                                            <option>3 Ay</option>
                                            <option>6 Ay</option>
                                            <option>9 Ay</option>
                                            <option>12 Ay</option>
                                              </b-form-select>
                                           
                                          </div>
                                        </div>

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Adet: ") }}</label
                                            >
                                          
                                            
                                            <input 
                                            type="text"
                                              class="form-control form-control-sm"
                                            v-model.number="requestPieces"
                                              
                                            />
                                            
                                           
                                          </div>
                                        </div>

                                        


                                       <div class="col-xxl-10">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Açıklama") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="requestDescription"
                                            />
                                          </div>
                                        </div>
                                        <div class="hstack gap-2 justify-content-end">
                                          <button type="button" id="degisiklikTalebiBtn" class="btn btn-danger" data-bs-dismiss="modal" 
                                           >
                                           {{ $t("t-close") }}
                                          </button>
                                          <button type="button" id="degisiklikTalebiBtn"  class="btn btn-success" @click="addRequest(); addRequestYonetici();">
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


            <!--Faturalandırma-->
            <div
              class="modal zoomIn"
              id="FaturaDetail"
              tabindex="-1"
              aria-labelledby="exampleModalgridLabel"
              aria-modal="true"
            >
              <div class="modal-dialog modal-xl">
                <div class="modal-content">
                  <div class="modal-header" style="background-color: #f1f1f1">
                    <h5 class="modal-title" id="exampleModalgridLabel">
                      {{ ("MAKBUZ") }}
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
                    
                    
                             <div class="text-left">
                                <h1>ALIŞAN LOJİSTİK A.Ş.</h1>
                             </div>
                              
                              <div class="text-right">
                                <img src="@/assets/images/common/alisan-logo-normal.png" alt="" height="60" />
                                <div>
                                  
                                  <p>{{ nowdate }}</p>
                               </div>
                               <div>
                        
                        <div class="section-spacer">
                           <h3>Adres</h3>
                            <div class="textarea"> 
                                İçerenköy Mahallesi. Değirmen Yolu Cd. No:28 Ataşehir/İstanbul
                              </div>
                        </div>
                    </div>


                              </div> <!--header-->

                              <div class="text-left">
                                <table  
                                    class="listingTable table align-middle table-nowrap">
                                    <thead class="table-light text-muted">
                                      <tr>
                                        <th class="sort" scope="col" >{{ ("Tedarikçi Firma") }}</th>
                                        <th class="sort" scope="col" >{{ ("Ürün") }}</th>
                                        <th class="sort" scope="col" >{{ ("Ürün Fiyatı") }}</th>
                                        <th class="sort" scope="col">{{ ("Adet") }}</th>
                                        <th class="sort" scope="col">{{ ("Tutar") }}</th>
                                        
                                      </tr>
                                    </thead>
                                    <tbody class="list form-check-all">
                                      <tr>
                                        
                                        <td>{{ requestSupplier }}</td>
                                        <td>{{ requestMaterial }}</td>
                                        <td>{{ ("10") }}</td>
                                        <td>{{ requestPieces }}</td>
                                        <td>{{ toplam }} {{ ("TL") }}</td>

                                       
                                      </tr>
                                    </tbody>
                                  </table>
                              </div>

                              <div class="text-right">
                                <div><b>Toplam: </b> {{ toplam }} TL
                                </div>
                                <div><b>KDV(%18): </b> {{ kdv }} TL
                                </div>
                                <div >
                                <h3> Toplam Tutar: {{ toptut }} TL</h3>
                                </div>
                                <div style="margin-top: 2cm;">
                                    <button v-on:click="printscreen();">
                                      <img src="@/assets/images/common/logo-yazici.png" alt="" height="30" />
                                      <label style="color: black;"> YAZDIR</label>
                                    </button>
                                </div>

                              </div>
                            
                            
                          

                        

                        
                  </div>
                </div>
              </div>
            </div>

<!--Kargo -->
<div
              class="modal zoomIn"
              id="KargoDetail"
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
                      {{ ("Kargo Detay") }}
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
                                              {{$t("Talep No") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="requestNo"
                                            />
                                          </div>
                                        </div>
                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{$t("t-it-has-request") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="requestor"
                                            />
                                          </div>
                                        </div>

                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-it-request-date") }}</label
                                            >
                                            <input
                                              type="date"
                                              class="form-control form-control-sm"
                                              v-model="requestDate"
                                              id="dateInput"
                                            />
                                          </div>
                                        </div>
                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Ödeme Şekli: ") }}</label
                                            >
                                          
                                            
                                            <b-form-select v-model="requestPaymentType">
                                            <option disabled value="">Lütfen Seçiniz</option>
                                            <option>Peşin</option>
                                            <option>3 Ay</option>
                                            <option>6 Ay</option>
                                            <option>9 Ay</option>
                                            <option>12 Ay</option>
                                              </b-form-select>
                                           
                                          </div>
                                        </div>

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Adet: ") }}</label
                                            >
                                          
                                            
                                            <input v-model.number="requestPieces"
                                              
                                            />
                                            
                                           
                                          </div>
                                        </div>

                                        


                                       <div class="col-xxl-10">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Açıklama") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="requestDescription"
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
                  </div>
                </div>
              </div>
            </div>

 <!--Kargo Yonetici -->
 <div
              class="modal zoomIn"
              id="KargoYoneticiDetail"
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
                      {{ ("Yönetici Onay") }}
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
                                              {{$t("Talep No") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="requestNo"
                                            />
                                          </div>
                                        </div>
                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{$t("t-it-has-request") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="requestor"
                                            />
                                          </div>
                                        </div>

                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-it-request-date") }}</label
                                            >
                                            <input
                                              type="date"
                                              class="form-control form-control-sm"
                                              v-model="requestDate"
                                              id="dateInput"
                                            />
                                          </div>
                                        </div>

                                      
                                        
                                        
                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Kategori : ") }}</label
                                            >
                                          
                                            
                                           <label>
                                            {{ requestCategory }}
                                           </label>
                                           
                                          </div>
                                        </div>
                                        

                                        <div class="col-xxl-5">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Depo : ") }}</label
                                            >
                                           <label>
                                            {{ requestDepot }}
                                           </label>
                                          </div>
                                        </div>
                                        

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Tedarikçi Firma: ") }}</label
                                            >
                                          
                                            
                                           <label>
                                            {{ requestSupplier }}
                                           </label>
                                           
                                          </div>
                                        </div>

                                        <div id="acompany" class="col-xxl-5" >
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Malzeme: ") }}</label
                                            >
                                          
                                            
                                          <label>
                                            {{ requestMaterial }}
                                          </label>

                                           
                                          </div>
                                        </div>

                                       

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Ödeme Şekli: ") }}</label
                                            >
                                          
                                            
                                           <label>
                                            {{ requestPaymentType }}
                                           </label>
                                           
                                          </div>
                                        </div>

                                        <div class="col-xxl-5">
                                          <div>
                                            
                                            <label
                                            for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Adet: ") }}</label
                                            >
                                          
                                            
                                           <label>
                                            {{ requestPieces }}
                                           </label>
                                            
                                           
                                          </div>
                                        </div>


                                       <div class="col-xxl-10">
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ ("Açıklama") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="requestDescription"
                                            />
                                          </div>
                                        </div>
                                        <div class="hstack gap-2 justify-content-end">
                                          <button type="button" id="degisiklikTalebiBtn"  class="btn btn-info" @click=" Status5();">
                                            {{ $t("Sipariş Alındı") }}
                                          </button>
                                          <button type="button" id="degisiklikTalebiBtn"  class="btn btn-warning" @click=" Status6();">
                                            {{ $t("Yolda") }}
                                          </button>
                                          <button type="button" id="degisiklikTalebiBtn"  class="btn btn-warning" @click=" Status7();">
                                            {{ $t("Şubede") }}
                                          </button>
                                          <button type="button" id="degisiklikTalebiBtn"  class="btn btn-success" @click="addRequestSiparis(); Status8();">
                                            {{ $t("Teslim Edildi") }}
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
                  {{ $t("t-my-access-demands") }}
                 
                </a>
              </li>
             
              <li class="nav-item">
                <a class="nav-link" data-bs-toggle="tab" href="#nav-badge-admin-requests" role="tab" aria-selected="false"
                  style="font-size: 13px">  
                  {{ $t("Satın Alma Yönetici Onayı") }}
                </a>
              </li> 

              <li class="nav-item">
                <a class="nav-link" data-bs-toggle="tab" href="#nav-badge-fatura" role="tab" aria-selected="false"
                  style="font-size: 13px">  
                  {{ $t("Faturalandırma") }}
                </a>
              </li> 

              <li class="nav-item">
                <a class="nav-link" data-bs-toggle="tab" href="#nav-badge-siparis" role="tab" aria-selected="false"
                  style="font-size: 13px">  
                  {{ $t("Stok") }}
                </a>
              </li> 
              <li class="nav-item">
                <a class="nav-link" data-bs-toggle="tab" href="#nav-badge-kargo" role="tab" aria-selected="false"
                  style="font-size: 13px">  
                  {{ $t("Kargo Durumu") }}
                </a>
              </li> 
              <li class="nav-item">
                <a class="nav-link" data-bs-toggle="tab" href="#nav-badge-kargo-yonetici" role="tab" aria-selected="false"
                  style="font-size: 13px">  
                  {{ $t("Kargo Durumu Yöneticisi") }}
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
                                        
                                        <th class="sort" scope="col" >{{ $t("t-situation") }}</th>
                                        <th class="sort" scope="col" >{{ $t("Talep No") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-it-request-date") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-it-has-request") }}</th>
                                        <th class="sort" scope="col">{{ $t("Kategori") }}</th>
                                        <th class="sort" scope="col">{{ $t("Depo") }}</th>
                                        <th class="sort" scope="col">{{ $t("Tedarikçi Firma") }}</th>
                                        <th class="sort" scope="col">{{ $t("Malzeme") }}</th>
                                        <th class="sort" scope="col">{{ $t("Ödeme Şekli") }}</th>
                                        <th class="sort" scope="col">{{ $t("Adet") }}</th>
                                        <th class="sort" scope="col">{{ $t("Açıklama") }}</th>
                                      </tr>
                                    </thead>
                                    <tbody class="list form-check-all">
                                      <tr v-for="request in Request" :key="request.id">
                                        
                                        <td >{{request.status  }}</td>
                                        <td >{{request.requestNo  }}</td>
                                        <td>{{ request.requestDate }}</td>
                                        <td>{{ request.requestor }}</td>
                                        <td>{{ request.requestCategory }}</td>
                                        <td>{{ request.requestDepot }}</td>
                                        <td>{{ request.requestSupplier }}</td>
                                        <td>{{ request.requestMaterial }}</td>
                                        <td>{{ request.requestPaymentType }}</td>
                                        <td>{{ request.requestPieces }}</td>
                                        <td>{{ request.requestDescription }}</td>
                                        <button
                                       
                                       type="button"
                                       class="btn btn-soft-dark waves-effect waves-light btn-sm"
                                       data-bs-toggle="modal"
                                       data-bs-target="#requestDetail"  
                                       @click="editClick2(request)"
                                      
                                     >
                                    
                                       {{ $t("Detay") }}
                                       
                             
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
              

            <!--bt admin onay tablo-->

            <div class="tab-pane" id="nav-badge-admin-requests" role="tabpanel">
   
                <div class="d-flex">
                  <div class="card-body">
                    <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
                      <div class="d-flex">
                        <div class="flex-grow-1 ms-2">
                          <div class="row">
                            <div class="card card-body">
                              <div class="card-body">
                                <div class=" table-responsive table-card" style="width: 100% !important" id="myYoneticiRequestTable">
                                  <table  style="width: 100% !important; margin-right: -200px;  " 
                                    class="listingTable table align-middle table-nowrap">
                                    <thead class="table-light text-muted">
                                      <tr>
                                    
                                        
                                      
                                        <th class="sort" scope="col" >{{ $t("Talep No") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-it-request-date") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-it-has-request") }}</th>
                                        <th class="sort" scope="col">{{ $t("Kategori") }}</th>
                                        <th class="sort" scope="col">{{ $t("Depo") }}</th>
                                        <th class="sort" scope="col">{{ $t("Tedarikçi Firma") }}</th>
                                        <th class="sort" scope="col">{{ $t("Malzeme") }}</th>
                                        <th class="sort" scope="col">{{ $t("Ödeme Şekli") }}</th>
                                        <th class="sort" scope="col">{{ $t("Adet") }}</th>
                                      </tr>
                                    </thead>
                                   <tbody class="list form-check-all">
                                      <tr v-for="request in RequestYonetici" :key="request.id" >
                                           
                                       
                                        <td >{{request.requestNo  }}</td>
                                        <td>{{ request.requestDate }}</td>
                                        <td>{{ request.requestor }}</td>
                                        <td>{{ request.requestCategory }}</td>
                                        <td>{{ request.requestDepot }}</td>
                                        <td>{{ request.requestSupplier }}</td>
                                        <td>{{ request.requestMaterial }}</td>
                                        <td>{{ request.requestPaymentType }}</td>
                                        <td>{{ request.requestPieces }}</td>
                                        <button
                             
              type="button"

              class="btn btn-soft-dark waves-effect waves-light btn-sm"
              data-bs-toggle="modal"
              data-bs-target="#BtAdminDetail"  
              @click="editClick(request); "                  
            >
           
              {{ $t("Detay") }}
              
    
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
             

 <!--Stok-->

 <div class="tab-pane" id="nav-badge-siparis" role="tabpanel">
   
   <div class="d-flex">
     <div class="card-body">
       <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
         <div class="d-flex">
           <div class="flex-grow-1 ms-2">
             <div class="row">
               <div class="card card-body">
                 <div class="card-body">
                   <div class=" table-responsive table-card" style="width: 100% !important" id="mySiparisRequestTable">
                     <table  style="width: 100% !important; margin-right: -200px;  " 
                       class="listingTable table align-middle table-nowrap">
                       <thead class="table-light text-muted">
                         <tr>
                       
                           
                          
                           <th class="sort" scope="col" >{{ $t("Talep No") }}</th>
                           <th class="sort" scope="col">{{ $t("t-it-request-date") }}</th>
                           <th class="sort" scope="col">{{ $t("t-it-has-request") }}</th>
                           <th class="sort" scope="col">{{ $t("Kategori") }}</th>
                           <th class="sort" scope="col">{{ $t("Depo") }}</th>
                           <th class="sort" scope="col">{{ $t("Tedarikçi Firma") }}</th>
                           <th class="sort" scope="col">{{ $t("Malzeme") }}</th>
                           <th class="sort" scope="col">{{ $t("Ödeme Şekli") }}</th>
                           <th class="sort" scope="col">{{ $t("Adet") }}</th>
                         </tr>
                       </thead>
                      <tbody class="list form-check-all">
                         <tr v-for="request in RequestSiparis" :key="request.id" >
                              
                          
                           <td >{{request.requestNo  }}</td>
                           <td>{{ request.requestDate }}</td>
                           <td>{{ request.requestor }}</td>
                           <td>{{ request.requestCategory }}</td>
                           <td>{{ request.requestDepot }}</td>
                           <td>{{ request.requestSupplier }}</td>
                           <td>{{ request.requestMaterial }}</td>
                           <td>{{ request.requestPaymentType }}</td>
                           <td>{{ request.requestPieces }}</td>
                           <button
                
 type="button"

 class="btn btn-soft-dark waves-effect waves-light btn-sm"
 data-bs-toggle="modal"
 data-bs-target="#SiparisDetail"  
 @click="editClick(request); "                  
>

 {{ $t("Detay") }}
 

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


   <!--Faturalandırma-->
   <div class="tab-pane" id="nav-badge-fatura" role="tabpanel">
   <div class="d-flex">
     <div class="card-body">
       <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
         <div class="d-flex">
           <div class="flex-grow-1 ms-2">
             <div class="row">
               <div class="card card-body">
                 <div class="card-body">
                   <div class=" table-responsive table-card" style="width: 100% !important" id="myFaturaRequestTable">
                     <table  style="width: 100% !important; margin-right: -200px;  " 
                       class="listingTable table align-middle table-nowrap">
                       <thead class="table-light text-muted">
                         <tr>
                       
                           
                          
                           <th class="sort" scope="col">{{ $t("t-it-request-date") }}</th>
                           <th class="sort" scope="col">{{ $t("Talep No") }}</th>
                           <th class="sort" scope="col">{{ $t("t-it-has-request") }}</th>
                           <th class="sort" scope="col">{{ $t("Kategori") }}</th>
                           <th class="sort" scope="col">{{ $t("Depo") }}</th>
                           <th class="sort" scope="col">{{ $t("Tedarikçi Firma") }}</th>
                           <th class="sort" scope="col">{{ $t("Malzeme") }}</th>
                           <th class="sort" scope="col">{{ $t("Ödeme Şekli") }}</th>
                           <th class="sort" scope="col">{{ $t("Adet") }}</th>
                         </tr>
                       </thead>
                      <tbody class="list form-check-all">
                         <tr v-for="request in RequestFatura" :key="request.id" >
                              
                          <td >{{request.requestNo }}</td>
                           <td>{{ request.requestDate }}</td>
                           <td>{{ request.requestor }}</td>
                           <td>{{ request.requestCategory }}</td>
                           <td>{{ request.requestDepot }}</td>
                           <td>{{ request.requestSupplier }}</td>
                           <td>{{ request.requestMaterial }}</td>
                           <td>{{ request.requestPaymentType }}</td>
                           <td>{{ request.requestPieces }}</td>
                           <button
                
 type="button"

 class="btn btn-soft-dark waves-effect waves-light btn-sm"
 data-bs-toggle="modal"
 data-bs-target="#FaturaDetail"  
 @click="editClick(request); Toplam(); Kdv(); Toplamtutar();"                  
>

 {{ $t("Faturalandır") }}
 

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

   <!--Kargo-->
   <div class="tab-pane" id="nav-badge-kargo" role="tabpanel">
   <div class="d-flex">
     <div class="card-body">
       <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
         <div class="d-flex">
           <div class="flex-grow-1 ms-2">
             <div class="row">
               <div class="card card-body">
                 <div class="card-body">
                   <div class=" table-responsive table-card" style="width: 100% !important" id="myKargoRequestTable">
                     <table  style="width: 100% !important; margin-right: -200px;  " 
                       class="listingTable table align-middle table-nowrap">
                       <thead class="table-light text-muted">
                         <tr>
                       
                           
                          <th class="sort" scope="col">{{ $t("Durum") }}</th>
                          
                           <th class="sort" scope="col">{{ $t("Talep No") }}</th>
                           <th class="sort" scope="col">{{ $t("t-it-request-date") }}</th>
                           <th class="sort" scope="col">{{ $t("t-it-has-request") }}</th>
                           <th class="sort" scope="col">{{ $t("Ödeme Şekli") }}</th>
                           <th class="sort" scope="col">{{ $t("Adet") }}</th>
                         </tr>
                       </thead>
                      <tbody class="list form-check-all">
                         <tr v-for="request in RequestKargo" :key="request.id" >
                          <td >{{request.status }}</td>
                          <td >{{request.requestNo }}</td>
                           <td>{{ request.requestDate }}</td>
                           <td>{{ request.requestor }}</td>
                           <td>{{ request.requestPaymentType }}</td>
                           <td>{{ request.requestPieces }}</td>
                           <button
                
 type="button"

 class="btn btn-soft-dark waves-effect waves-light btn-sm"
 data-bs-toggle="modal"
 data-bs-target="#KargoDetail"  
 @click="editClick(request); "                  
>

 {{ $t("Detay") }}
 

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

   <!--Kargo Yonetici-->
   <div class="tab-pane" id="nav-badge-kargo-yonetici" role="tabpanel">
   <div class="d-flex">
     <div class="card-body">
       <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
         <div class="d-flex">
           <div class="flex-grow-1 ms-2">
             <div class="row">
               <div class="card card-body">
                 <div class="card-body">
                   <div class=" table-responsive table-card" style="width: 100% !important" id="myKargoYoneticiTable">
                     <table  style="width: 100% !important; margin-right: -200px;  " 
                       class="listingTable table align-middle table-nowrap">
                       <thead class="table-light text-muted">
                         <tr>
                       
                           
                          
                           <th class="sort" scope="col">{{ $t("t-it-request-date") }}</th>
                           <th class="sort" scope="col">{{ $t("Talep No") }}</th>
                           <th class="sort" scope="col">{{ $t("t-it-has-request") }}</th>
                           <th class="sort" scope="col">{{ $t("Kategori") }}</th>
                           <th class="sort" scope="col">{{ $t("Depo") }}</th>
                           <th class="sort" scope="col">{{ $t("Tedarikçi Firma") }}</th>
                           <th class="sort" scope="col">{{ $t("Malzeme") }}</th>
                           <th class="sort" scope="col">{{ $t("Ödeme Şekli") }}</th>
                           <th class="sort" scope="col">{{ $t("Adet") }}</th>
                         </tr>
                       </thead>
                      <tbody class="list form-check-all">
                         <tr v-for="request in RequestKargoYonetici" :key="request.id" >
                              
                          <td >{{ request.requestDate}}</td>
                           <td>{{request.requestNo }}</td>
                           <td>{{ request.requestor }}</td>
                           <td>{{ request.requestCategory }}</td>
                           <td>{{ request.requestDepot }}</td>
                           <td>{{ request.requestSupplier }}</td>
                           <td>{{ request.requestMaterial }}</td>
                           <td>{{ request.requestPaymentType }}</td>
                           <td>{{ request.requestPieces }}</td>
                           <button
                
 type="button"

 class="btn btn-soft-dark waves-effect waves-light btn-sm"
 data-bs-toggle="modal"
 data-bs-target="#KargoYoneticiDetail"  
 @click="editClick(request); "                  
>

 {{ $t("Detay") }}
 

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
