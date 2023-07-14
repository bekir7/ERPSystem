<template>
    <div class="row font">
        <div class="col-lg-12">
            <div class="card">
                <div class="card-body">
                    <div class="card font">
                        <div class="card-header align-items-center d-flex">
                            <h4 class="card-title mb-0 flex-grow-1">
                                {{ $t("t-new-announcement") }}
                            </h4>
                        </div>
                        <div class="tab-pane" id="nav-badge-damage" role="tabpanel">
                            <div class="d-flex">
                                <div class="flex-grow-1 ms-2">
                                    <div class="row">
                                        <div class="card-body">
                                            <div class=" table-responsive table-card" style="width: 100% !important">
                                                <div class="card-body">
                                                    <div class="row g-3">
                                                        <div class="form-group col-xxl-12">
                                                        </div>
                                                        <div class="col-xxl-3">
                                                            <label class="form-label form-label-sm">
                                                                {{ $t("t-importance-level") }}
                                                                <span class="text-danger">*</span>
                                                            </label>
                                                            <div class="hstack gap-2 flex-wrap">
                                                                <input type="radio" class="btn-check"
                                                                    name="importance-level" id=" il1" v-if="entityModel"
                                                                    v-model="entityModel.Level" value="D" />
                                                                <label class="btn btn-outline-primary" for=" il1">{{
                                                                    $t("t-low") }}</label>
                                                                <input type="radio" class="btn-check"
                                                                    name="importance-level" id=" il2" v-if="entityModel"
                                                                    v-model="entityModel.Level" value="N">
                                                                <label class="btn btn-outline-warning"
                                                                    for=" il2">Normal</label>
                                                                <input type="radio" class="btn-check"
                                                                    name="importance-level" id=" il3" v-if="entityModel"
                                                                    v-model="entityModel.Level" value="Y">
                                                                <label class="btn btn-outline-danger" for=" il3">{{
                                                                    $t("t-high") }}</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-xxl-4">
                                                            <label class="form-label">
                                                                {{ $t("t-announcement-type") }}
                                                                <span class="text-danger">*</span></label>
                                                            <div class="hstack gap-2 flex-wrap">
                                                                <input type="radio" class="btn-check"
                                                                    name="announcement-type" id=" at4" v-if="entityModel"
                                                                    v-model="entityModel.Type" value="A">
                                                                <label class="btn btn-outline-success" for=" at4">{{
                                                                    $t("t-announcement") }}</label>
                                                                <input type="radio" class="btn-check"
                                                                    name="announcement-type" id=" at5" v-if="entityModel"
                                                                    v-model="entityModel.Type" value="I">
                                                                <label class="btn btn-outline-success" for=" at5">{{
                                                                    $t("t-inform") }}</label>
                                                                <input type="radio" class="btn-check"
                                                                    name="announcement-type" id=" at6" v-if="entityModel"
                                                                    v-model="entityModel.Type" value="I">
                                                                <label class="btn btn-outline-success" for=" at6">{{
                                                                    $t("t-clue") }}</label>
                                                                <input type="radio" class="btn-check"
                                                                    name="announcement-type" id=" at7" v-if="entityModel"
                                                                    v-model="entityModel.Type" value="C">
                                                                <label class="btn btn-outline-success" for=" at7">{{
                                                                    $t("t-guide") }}</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-xxl-5 mb-3">
                                                            <label class="form-label">
                                                                {{ $t("t-informed-department") }}
                                                                <span class="text-danger">*</span></label>
                                                            <Multiselect :placeholder="$t('t-choose')" style="height: 39px"
                                                                v-if="entityModel" v-model="entityModel.DepartmentId"
                                                                :close-on-select="true" :searchable="true"
                                                                :create-option="false" :options="departments" mode="tags" />
                                                        </div>

                                                        <div class="form-group col-xxl-12">
                                                            <label class="form-label"> {{ $t("t-subject") }}</label>
                                                            <input class="form-control" id="subject" v-if="entityModel"
                                                                v-model="entityModel.Subject">

                                                        </div>
                                                        <div class="form-group col-xxl-12">
                                                            <label class="form-label">{{ $t("t-announcement-text")
                                                            }}</label>
                                                            <vue-editor v-model="content" :editor-toolbar="customToolbar"
                                                                @change="onContentChange"></vue-editor>
                                                            <label class="form-label" style="color:#ff000080;">Metni
                                                                yazdıktadan sonra onay
                                                                kutusuna tıklayarak
                                                                metni onaylayınız. Aksi taktirde yaptığınız değişiklikler
                                                                kaydedilmeyecektir.</label><i
                                                                class="m-lg-2 ri-chat-check-fill ri-2x" @click="descChange">
                                                            </i>
                                                            <p v-if="!editing && save" style="color:green;">Duyuru metni
                                                                onaylanmıştır.</p>
                                                            <p v-if="editing" style="color:blue;">Metin düzenleniyor...</p>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <input class="form-control" type="file" id="formFile">
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-12">
                                                                <edit-tool-bar :enableSave="true" :enableDelete="true"
                                                                    :parentModel="entityModel"
                                                                    :parentController="'Announcement'"></edit-tool-bar>
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
</template>

<script>

import appConfig from "@/../app.config";
import { appAxios } from "kurumsalcontainer/appAxios";
import $ from "jquery";
import editToolBar from "kurumsalcontainer/editToolBar";
import Multiselect from "@vueform/multiselect";
import "@vueform/multiselect/themes/default.css";
import { VueEditor } from "vue3-editor";




export default {

    mixins: ['getItemMixin'],
    components: {
        editToolBar,
        Multiselect,
        VueEditor
    },
    name: "new-announcement",
    data() {

        return {
            title: "Yeni Duyuru",
            items: [
                {
                    text: this.$t("t-create-announcement"),
                    href: "/",
                },
                {
                    text: "Yeni Duyuru",
                    active: true,
                },
            ],
            departments: [],
            entityModel: undefined,
            content: "",
            save: false,
            editing: false,
            customToolbar: [
                [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
                ["bold", "italic", "underline", "strike"],
                [{ list: "ordered" }, { list: "bullet" }],
            ]
        }
    },
    async created() {
        let self = this;
        self.getRecord();
        await self.getDepartments().then((res) => {
            self.departments = res;
            console.log(self.departments);
        });
    },
    methods: {
        onContentChange() {
            this.editing = true;
        },
        descChange() {
            let self = this;
            self.entityModel.Description = self.content;
            self.save = true;
            this.editing = false;
            setTimeout(() => {
                self.save = false;
            }, 2000);
        },
        getRecord: function () {
            let self = this;
            let routeId = self.$route.query.id;
            if (routeId == undefined) {
                let config = {
                    headers: {
                        controllerName: "announcement",
                    },
                };
                const path = process.env.SERVICE_ADDRESS + "GetMeta";
                appAxios
                    .get(path, config)
                    .then((res) => {
                        self.entityModel = JSON.parse(String(res.data));
                        self.entityModel.UserId = 1016;
                        self.entityModel.Id = 0;

                    })
                    .catch((error) => console.log(error.data));
            } else {
                appAxios
                    .get(process.env.SERVICE_ADDRESS + "api/Announcement/?id=" + routeId)
                    .then((res) => {
                        self.entityModel = res.data.Data;
                        self.content = self.entityModel.Description;
                    }).catch((error) => console.log(error.data));
            }
        },
        dblclick(dataId) {
            let self = this;
            self.$router.push({ name: 'new-announcement', query: { id: dataId } });
        },

    },
};
</script>
<style>
@import url("https://fonts.googleapis.com/css2?family=Nunito:wght@300;400;500;600;700&display=swap");

@font-face {
    font-family: "Nunito";
    src: url("https://fonts.googleapis.com/css2?family=Nunito:wght@300;400;500;600;700&display=swap");
}

.font {
    font-family: "Nunito", sans-serif;
}

.reset {
    all: revert;
}

.ri-chat-check-fill:hover {
    color: #3d78e3 !important;
    cursor: pointer !important;
}

.ri-chat-check-fill:focus {
    color: #3d78e3 !important;
    cursor: pointer !important;
}
</style>