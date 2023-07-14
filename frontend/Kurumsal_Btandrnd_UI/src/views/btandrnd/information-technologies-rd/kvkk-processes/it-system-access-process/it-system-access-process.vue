<script>
import { defineAsyncComponent } from "vue";

const Layout = defineAsyncComponent(() => import("kurumsalbody/Layout"));
const PageHeader = defineAsyncComponent(() => import("kurumsalbody/PageHeader"));
import appConfig from "@/../app.config";
import axios from "axios";
import $ from 'jquery';
export default {
 
    page: {
    title: "BT Sistem Erişim Süreci",
    meta: [
      {
        name: "description",
        content: appConfig.description,
      },
    ],
  },
  components: {
    Layout,
    PageHeader,
  },
  mounted() {
    setTimeout(() => {
     this.created();
     this.createdBt();
     this.createdIt();
    }, 100);
  },
  
  data() {
    
    return {
      open: false,
      name:"app",
      email: "email@adress.com",
      password: "password123",
        Request:[],
        BtRequest:[],
        ItRequest:[],
        requestNo:0,
        requestor:null,
        requestDate:null,
        systemName:null,
        accessType:null,
        accessType2:[],
        description:null,
        status:"Bt Admin Bekleniyor",
        status1:"It Admin Bekleniyor",
        status2:"Reddedildi",
        status3:"Tamamlandı",
      descriptionDeny:null,
      descriptionDenyIt:null,
      checked:[],
        title: this.$t("t-it-system-access-process"),
      items: [
        {
            text: this.$t("t-kvkk-processes"),
          href: "/",
        },
        {
            text: this.$t("t-it-system-access-process"),
          active: true,
        },
      ],
      
      
    };
    
  },
  
  methods:{
    
    /*Bt Onay Detay Butonundaki veriler*/ 
    editClick(request){
        this.requestNo=request.requestNo;
        this.requestor=request.requestor;
        this.systemName=request.systemName,
        this.accessType=request.accessType,
        this.accessType2=request.accessType2,
        this.description=request.description,
        this.requestDate=request.requestDate
    },
    editClick2(request){
        this.descriptionDeny=request.descriptionDeny
    },
    
     //Gönder Buton
     addRequest () {
                   
        var newRequest = {
       
        status:this.status,
        requestNo: this.requestNo,
        requestor: this.requestor,
        requestDate:this.requestDate,
        systemName:this.systemName,
        accessType:this.accessType,
        accessType2:this.accessType2,
        description:this.description
}
        axios.post("http://localhost:54558/api/requestbt/create", newRequest)
        .then(res => this.Request = res.data)
},

 //BtOnay Onay Buton
    addBt(){
      var newRequest ={
        
        requestNo: this.requestNo,
        requestor: this.requestor,
        requestDate:this.requestDate,
        systemName:this.systemName,
        accessType:this.accessType,
        accessType2:this.accessType2,
        description:this.description
      }
      axios.post("http://localhost:54558/api/btrequest/createbt", newRequest)
                        .then(res => this.BtRequest = res.data)
                        .catch(err => console.log(err))
},
//It Onay Buton
addIt(){
      var newRequest ={
       
        requestNo: this.requestNo,
        requestor: this.requestor,
        requestDate:this.requestDate,
        systemName:this.systemName,
        accessType:this.accessType,
        accessType2:this.accessType2,
        description:this.description
      }
      axios.post("http://localhost:54558/api/itrequest/createit", newRequest)
                        .then(res => this.ItRequest = res.data)
                        .catch(err => console.log(err))
},
  //itadmin bekleniyor yazdırıyoruz
 saveEdit () {
                   
                    var newRequest = {
                        status: this.status1,
                        requestNo: this.requestNo,
                     requestor: this.requestor,
                     requestDate:this.requestDate,
                     systemName:this.systemName,
                     accessType:this.accessType,
                     accessType2:this.accessType2,
                     description:this.description
                    }
                    axios.post("http://localhost:54558/api/requestbt/update2", newRequest)
                        .then(res => this.Request = res.data)
                        .catch(err => console.log(err))
                },
    
//Reddedildi yazdırıyoruz
Status(){
 var newStatus={
  descriptionDeny:this.descriptionDeny,
    status: this.status2,
    requestNo: this.requestNo,
    requestor: this.requestor,
    requestDate:this.requestDate,
    systemName:this.systemName,
    accessType:this.accessType,
    accessType2:this.accessType2,
    description:this.description
  }
  axios.post("http://localhost:54558/api/requestbt/update2", newStatus)
                        .then(res => this.Request = res.data)
                        .catch(err => console.log(err))
},

Status2(){
 var newStatus={
  descriptionDeny:this.descriptionDeny,
    status: this.status3,
    requestNo: this.requestNo,
    requestor: this.requestor,
    requestDate:this.requestDate,
    systemName:this.systemName,
    accessType:this.accessType,
    accessType2:this.accessType2,
    description:this.description
  }
  axios.post("http://localhost:54558/api/requestbt/update2", newStatus)
                        .then(res => this.Request = res.data)
                        .catch(err => console.log(err))
},
//bt Tabledan siliyoruz
deleteRequest2 (id) {
          axios.delete("http://localhost:54558/api/btrequest/Delete/"+id)
                        .then(res => this.BtRequest = res.data)
                        .catch(err => console.log(err))
  },
  deleteRequest3 (id) {
          axios.delete("http://localhost:54558/api/itrequest/Delete/"+id)
                        .then(res => this.ItRequest = res.data)
                        .catch(err => console.log(err))
                },
               
created() {
      axios
        .get("http://localhost:54558/api/requestbt")
        .then(({ data }) => {
          this.Request = data;
          this.$nextTick(() => {
            $("#myRequestTable").DataTable({
             
             
            });
          });
        })
        .catch((error) => console.log(error.data));
    },
  createdBt() {
      axios
        .get("http://localhost:54558/api/btrequest")
        .then(({ data }) => {
          this.BtRequest = data;
          this.$nextTick(() => {
            $("#myBTRequestTable").DataTable({
             
             
            });
          });
        })
        .catch((error) => console.log(error.data));
    },
    createdIt() {
      axios
        .get("http://localhost:54558/api/itrequest")
        .then(({ data }) => {
          this.ItRequest = data;
          this.$nextTick(() => {
            $("#myItRequestTable").DataTable({
          });
          });
        })
        .catch((error) => console.log(error.data));
    },
}

}

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
              {{ $t("t-new-access-request") }}<!--yeni erişim talebi-->
              <br /><br />
          </button>
          <!--it yönetici modal-->

          <div
              class="modal zoomIn"
              id="itYoneticiDetail"
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
                      {{ ("ERİŞİM TALEBİ") }}
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
                                          <h5>
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-requestt-no") }} :  </label
                                            >
                                            
                                              <label>
                                                {{requestNo}}
                                              </label>
                                            
                                            
                                          </div>
                                        </h5>
                                        </div>
                                        <div class="col-xxl-5">
                                          <h5>
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-requestor") }}:</label
                                            >
                                            <label>
                                              {{requestor}}
                                            </label>
                                          </div>
                                        </h5>
                                        </div>
                                        <div class="col-xxl-5">
                                          <h5>
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-request-date") }}</label
                                            >
                                            <input
                                              type="date"
                                              class="form-control form-control-sm"
                                              v-model="requestDate"
                                              id="dateInput"
                                            />
                                          </div>
                                        </h5>
                                        </div>
                                        
                                          <div class="col-xxl-5">
                                            <h5>
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-system-name-to-access") }} : 
                                              </label
                                            >
                                            <label>{{ systemName }}</label>
                                          </div>
                                        </h5>
                                        </div>

                                        <div class="col-xxl-5">
                                          
                                          <div>
                                            <h5>
                                            <div>{{ $t("t-access-type") }}</div></h5>
                                            <br>
                                            <b-form-radio type="radio" id="database" value="t-database" v-model="accessType"></b-form-radio>
                                              
                                              <label for="database">{{ $t("t-database") }}</label>
                                              <br>
                                              <b-form-radio type="radio" id="server" value="t-server" v-model="accessType"></b-form-radio>
                                              <label for="server">{{ $t("t-server") }}</label>
                                              <br>
                                              <b-form-radio type="radio" id="table" value="t-table" v-model="accessType"></b-form-radio>
                                              <label for="table">{{ $t("t-table") }}</label>
                                              <br>
                                          </div>
                                        </div>
                                      


                                        <div class="col-xxl-5">
                                          <div>
                                            <h5>
                                            <div>{{ $t("t-access-type2") }}</div></h5>
                                            <br>
                                            <b-form-checkbox type="checkbox" id="read" value="t-read" v-model="accessType2"></b-form-checkbox>
                                              
                                              <label for="t-read">{{ $t("t-read") }}</label>
                                              <br>
                                              <b-form-checkbox type="checkbox" id="write" value="t-write" v-model="accessType2"></b-form-checkbox>
                                              <label for="t-write">{{$t("t-write") }}</label>
                                              <br>
                                              <b-form-checkbox type="checkbox" id="change" value="t-change" v-model="accessType2"></b-form-checkbox>
                                              <label for="t-change">{{ $t("t-change") }}</label>
                                              <br>
                                          </div>
                                        </div>
                                        


                                        
                                        <div class="col-xxl-10">
                                          <h5>
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-description") }} : </label
                                            >
                                            <label>{{ description }} </label>
                                          </div>
                                        </h5>
                                        </div>
                                        <div class="hstack gap-2 justify-content-end">
                                          <b-button data-bs-toggle="modal" data-bs-target="#ItAdminRefuse"  variant="danger" > {{ $t("t-deny") }}
                                          </b-button>
                                       <!--PopUp-->
                                        <div>
                                          <b-modal
                                            hide-footer
                                            id="ItAdminRefuse"
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
                                               <b-button @click="deleteRequest3(requestNo); Status(); "> 
                                                        {{ $t("t-deny")}}

                                               </b-button>
                                              </b-form-group>
                                            </form>
                                          </b-modal>
                                        </div>
                                          <b-button data-bs-toggle="table" variant="success" @click="Status2(); deleteRequest3(requestNo);"> {{ $t("t-accept") }}</b-button>
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


            <!--BT onay-->
            <div
              class="modal zoomIn"
              id="btAdminDetail"
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
                                          <h5>
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-requestt-no") }} : </label
                                            >
                                            
                                              <label>
                                                {{requestNo}}
                                              </label>
                                            
                                            
                                          </div>
                                        </h5>
                                        </div>
                                        <div class="col-xxl-5">
                                          <h5>
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-requestor") }}:</label
                                            >
                                            <label>
                                              {{requestor}}
                                            </label>
                                          </div>
                                        </h5>
                                        </div>
                                        <div class="col-xxl-5">
                                          <h5>
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-request-date") }}</label
                                            >
                                            <input
                                              type="date"
                                              class="form-control form-control-sm"
                                              v-model="requestDate"
                                              id="dateInput"
                                            />
                                          </div>
                                        </h5>
                                        </div>
                                        
                                          <div class="col-xxl-5">
                                            <h5>
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-system-name-to-access") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="systemName"
                                            />
                                          </div>
                                        </h5>
                                        </div>

                                        <div class="col-xxl-5">
                                          <h5>
                                          <div>
                                            <div>{{ $t("t-access-type") }}</div>
                                            <br>
                                            <b-form-radio type="radio" id="database" value="t-database" v-model="accessType"></b-form-radio>
                                              
                                              <label for="database">{{ $t("t-database") }}</label>
                                              <br>
                                              <b-form-radio type="radio" id="server" value="t-server" v-model="accessType"></b-form-radio>
                                              <label for="server">{{ $t("t-server") }}</label>
                                              <br>
                                              <b-form-radio type="radio" id="table" value="t-table" v-model="accessType"></b-form-radio>
                                              <label for="table">{{ $t("t-table") }}</label>
                                              <br>
                                          </div>
                                        </h5>
                                        </div>
                                      


                                        <div class="col-xxl-5">
                                          <h5>
                                          <div>
                                            <div>{{ $t("t-access-type2") }}</div>
                                            <br>
                                            <b-form-checkbox type="checkbox" id="read" value="t-read" v-model="accessType2"></b-form-checkbox>
                                              
                                              <label for="t-read">{{ $t("t-read") }}</label>
                                              <br>
                                              <b-form-checkbox type="checkbox" id="write" value="t-write" v-model="accessType2"></b-form-checkbox>
                                              <label for="t-write">{{$t("t-write") }}</label>
                                              <br>
                                              <b-form-checkbox type="checkbox" id="change" value="t-change" v-model="accessType2"></b-form-checkbox>
                                              <label for="t-change">{{ $t("t-change") }}</label>
                                              <br>
                                          </div>
                                        </h5>
                                        </div>
                                        


                                        
                                        <div class="col-xxl-10">
                                          <h5>
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-description") }}</label
                                            >
                                           <label>{{ description }}</label>
                                          </div>
                                        </h5>
                                        </div>
                                        <div class="hstack gap-2 justify-content-end">
                                          <b-button data-bs-toggle="modal" data-bs-target="#BtAdminRefuse"  variant="danger" > {{ $t("t-deny") }}
                                          </b-button>
                                          
  
                  <!--PopUp-->
                    <div>
                                          <b-modal
                                            hide-footer
                                            id="BtAdminRefuse"
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
                                               <b-button @click="deleteRequest2(requestNo); Status(); "> 
                                                        {{ $t("t-deny")}}

                                               </b-button>
                                              </b-form-group>
                                            </form>
                                          </b-modal>
                                        </div>

                                          <b-button data-bs-toggle="table" data-bs-target="#nav-badge-it-confirmation-page" variant="success" @click="addIt(); saveEdit(); deleteRequest2(requestNo);" > {{ $t("t-accept") }}</b-button>
                                         
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
                                              {{ $t("t-deny-description") }} : </label
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
                        <h4 class="modal-title" id="exampleModalgridLabel">
                      {{ $t("t-access-request") }}
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
                                          <h5>
                                          <div>
                                            
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                           
                                              {{ $t("t-requestt-no") }}</label
                                            >
                                          
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="requestNo"
                                            />
                                          </div>
                                        </h5>
                                        </div>
                                        <div class="col-xxl-5">
                                          <h5>
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-requestor") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="requestor"
                                            />
                                          </div>
                                        </h5>
                                        </div>
                                       
                                        <div class="col-xxl-5">
                                          <h5>
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-request-date") }}</label
                                            >
                                            <input
                                              type="date"
                                              class="form-control form-control-sm"
                                              v-model="requestDate"
                                              id="dateInput"
                                            />
                                          </div>
                                        </h5>
                                        </div>
                                        
                                          <div class="col-xxl-5">
                                            <h5>
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-system-name-to-access") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="systemName"
                                            />
                                          </div>
                                        </h5>
                                        </div>

                                        <div class="col-xxl-5" >
                                          <div>
                                            <h5>
                                            <div >{{ $t("t-access-type") }}</div></h5>
                                            <br>
                                            <b-form-radio type="radio" id="database" value="t-database" v-model="accessType"></b-form-radio>
                                              
                                              <label for="database"> {{  $t( "t-database") }} </label>
                                              <br>
                                              <b-form-radio type="radio" id="server" value="t-server" v-model="accessType"></b-form-radio>
                                              <label for="server"> {{  $t( "t-server") }} </label>
                                              <br>
                                              <b-form-radio type="radio" id="table" value="t-table" v-model="accessType"></b-form-radio>
                                              <label for="table"> {{  $t( "t-table") }} </label>
                                              <br>
                                          </div>
                                        </div>
                                      


                                        <div class="col-xxl-5">
                                          <div>
                                           
                                            <h5>
                                            <div >{{ $t("t-access-type2") }}</div></h5>
                                            
                                          
                                            <br>
                                            <b-form-checkbox type="checkbox" id="read" value="t-read" v-model="accessType2"></b-form-checkbox>
                                              
                                              <label for="t-read"> {{ $t("t-read") }} </label>
                                              <br>
                                            
                                              <b-form-checkbox type="checkbox" id="write" value="t-write" v-model="accessType2"></b-form-checkbox>
                                              <label for="t-write"> {{$t("t-write") }} </label>
                                              <br>
                                              <b-form-checkbox type="checkbox" id="change" value="t-change" v-model="accessType2"></b-form-checkbox>
                                              <label for="t-change"> {{ $t("t-change") }} </label>
                                              <br>
                                              
                                          </div>
                                        </div>
                                       <div class="col-xxl-10">
                                        <h5>
                                          <div>
                                            <label
                                              for="birim"
                                              class="form-label form-label-sm"
                                            >
                                              {{ $t("t-description") }}</label
                                            >
                                            <input
                                              type="text"
                                              class="form-control form-control-sm"
                                              v-model="description"
                                            />
                                          </div>
                                        </h5>
                                        </div>
                                        <div class="hstack gap-2 justify-content-end">
                                          <button type="button" id="degisiklikTalebiBtn" class="btn btn-danger" color="red" data-bs-dismiss="modal" 
                                           >
                                            {{ $t("t-close") }}
                                          </button>
                                          <button type="button" id="degisiklikTalebiBtn"  class="btn btn-success" @click="addRequest(); addBt();">
                                            {{ $t("t-send") }}
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

            <div class="modal"  >
    <h1>Welcome!</h1>
    <input
      type="text"
      name="username"
      id="username"
      placeholder="User Name"
      :style="input"
    />
    <br />
    <input
      type="password"
      name="password"
      id="password"
      placeholder="P@$$W0RD"
      :style="input"
    />
    <br />
    <input
      type="button"
      value="Done!"
      class="btn btn-soft-dark waves-effect waves-light btn-sm" 
      data-bs-toggle="modal"
      data-bs-target="#btLogin"  
      @click="editClick(BtRequest)"
    />
    <br />
  </div>
 
        
      
    
    <ul class="nav nav-tabs nav-justified mb-3" role="tablist">
      <li class="nav-item">
                <a class="nav-link active" data-bs-toggle="tab" href="#nav-badge-my-requests" role="tab"
                  aria-selected="true" style="font-size: 13px">
                  {{ $t("t-my-requests") }}
               </a>
              </li>  
              <li class="nav-item">
                <a class="nav-link" data-bs-toggle="tab" href="#nav-badge-bt-confirmation-page" role="tab" aria-selected="false"
                  style="font-size: 13px">  
                  {{ $t("t-bt-confirmation-page") }}
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link" data-bs-toggle="tab" href="#nav-badge-it-confirmation-page" role="tab" aria-selected="false"
                  style="font-size: 13px">  
                  {{ $t("t-it-confirmation-page") }}
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
                                <div class=" table-responsive table-card" style="width: 100% !important" >
                                  <table style="width: 100% !important; margin-right: -200px; " id="myRequestTable"
                                    class="listingTable table align-middle table-nowrap">
                                    <thead class="table-light text-muted">
                                      <tr>
                                        <th class="sort" scope="col" >{{ $t("t-situation") }}</th>
                                        <th class="sort" scope="col" >{{ $t("t-requestt-no") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-requestor") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-request-date") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-system-name-to-access") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-access-type") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-access-type2") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-description") }}</th>
                                        <th class="sort" scope="col">İşlem</th>
                                      </tr>
                                    </thead>
                                    <tbody class="list form-check-all">
                                      <tr v-for="request in Request" :key="request.id">
                                        <td >{{request.status  }}</td>
                                        <td >{{ request.requestNo }}</td>
                                        <td>{{ request.requestor }}</td>
                                        <td>{{ request.requestDate }}</td>
                                        <td>{{ request.systemName }}</td>
                                        <td>{{ request.accessType }}</td>
                                        <td>{{ request.accessType2 }}</td>
                                        <td>{{ request.description }}</td>
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
              <div class="tab-pane active" id="nav-badge-bt-confirmation-page" role="tabpanel">
               
                <!-- Bt onay tablo -->
                <div class="d-flex">
                  <div class="card-body">
                    <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
                      <div class="d-flex">
                        <div class="flex-grow-1 ms-2">
                          <div class="row">
                            <div class="card card-body">
                              <div class="card-body">
                                <div class=" table-responsive table-card" style="width: 100% !important" id="myBTRequestTable">
                                  <table style="width: 100% !important; margin-right: -200px; " 
                                    class="listingTable table align-middle table-nowrap">
                                    <thead class="table-light text-muted">
                                      <tr>
                                        <th class="sort" scope="col" >{{ $t("t-situation") }}</th>
                                        <th class="sort" scope="col" >{{ $t("t-requestt-no") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-requestor") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-request-date") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-system-name-to-access") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-access-type") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-access-type2") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-description") }}</th>
                                        <th class="sort" scope="col">İşlem</th>
                                      </tr>
                                    </thead>
                                    <tbody class="list form-check-all">
                                      <tr v-for="request in BtRequest" :key="request.id">
                                        <td >{{  }}</td>
                                        <td >{{ request.requestNo }}</td>
                                        <td >{{ request.requestor }}</td>
                                        <td >{{ request.requestDate }}</td>
                                        <td >{{ request.systemName }}</td>
                                        <td >{{ request.accessType }}</td>
                                        <td >{{ request.accessType2 }}</td>
                                        <td >{{ request.description }}</td>
                                        
                                        
                                        <button
                                       
              type="button"
              class="btn btn-soft-dark waves-effect waves-light btn-sm"
              data-bs-toggle="modal"
              data-bs-target="#btAdminDetail"  
              @click="editClick(request)"
             
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
              <div class="tab-pane active" id="nav-badge-it-confirmation-page" role="tabpanel">
                
                <!-- It Yönetici tablo -->
                <div class="d-flex">
                  <div class="card-body">
                    <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
                      <div class="d-flex">
                        <div class="flex-grow-1 ms-2">
                          <div class="row">
                            <div class="card card-body">
                              <div class="card-body">
                                <div class=" table-responsive table-card" style="width: 100% !important" >
                                  <table style="width: 100% !important; margin-right: -200px; " id="myItRequestTable"
                                    class="listingTable table align-middle table-nowrap">
                                    <thead class="table-light text-muted">
                                      <tr>
                                        <th class="sort" scope="col" >{{ $t("t-situation") }}</th>
                                        <th class="sort" scope="col" >{{ $t("t-requestt-no") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-requestor") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-request-date") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-system-name-to-access") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-access-type") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-access-type2") }}</th>
                                        <th class="sort" scope="col">{{ $t("t-description") }}</th>
                                        <th class="sort" scope="col">İşlem</th>
                                      </tr>
                                    </thead>
                                    <tbody class="list form-check-all">
                                      <tr v-for="request in ItRequest" :key="request.id">
                                        <td >{{  }}</td>
                                        <td >{{ request.requestNo }}</td>
                                        <td >{{ request.requestor }}</td>
                                        <td >{{ request.requestDate }}</td>
                                        <td >{{ request.systemName }}</td>
                                        <td >{{ request.accessType }}</td>
                                        <td >{{ request.accessType2 }}</td>
                                        <td >{{ request.description }}</td>
                                       
                                        <button
                                       
              type="button"
              class="btn btn-soft-dark waves-effect waves-light btn-sm"
              data-bs-toggle="modal"
              data-bs-target="#itYoneticiDetail"  
              @click="editClick(request)"
             
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