<template>
    <div class="card font">
        <div class="card-body">
            <div class="tab-pane" id="nav-badge-avoied" role="tabpanel">
                <div class="d-flex">
                    <div class="flex-grow-1 ms-2">
                        <div class="row">
                            <div class="card card-body" style="width: 200px !important">
                                <div class="card-body">
                                    <div class="table-responsive table-card mb-1">
                                        <table id="announcementTable" class=" table align-middle ">
                                            <thead class="table-light text-muted"></thead>
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
</template>
  
  
<script>
import appConfig from "@/../app.config";
import { appAxios } from "kurumsalcontainer/appAxios";
import $ from "jquery";


export default {

    name: "list-announcement",
    data() {
        return {
            title: "Tüm Liste",
            items: [
                {
                    text: this.$t("t-list-announcement"),
                    href: "/",
                },
                {
                    text: "yeni duyuru",
                    active: true,
                },
            ],
            tables: undefined,
            entityModel: undefined,
            dataTable: undefined,
            columns: undefined,
        }
    },
    mounted() {
        let self = this;
        setTimeout(() => {
            self.getAnnouncementTable();
        }, 100);
    },


    methods: {
        createTable() {
            let self = this;
            let filter= [];
            filter= [{ index: 6, value: '||' }]
            self.dataTable = self.createDataTables($("#announcementTable"), "AnnouncementOdata", 0, self.columns, filter);
        },
        getAnnouncementTable(listAnnouncement) {
            let self = this;
            self.columns = [
                { mData: "Id", sType: "numeric", sTitle: "Id" },
                // { mData: "User.Name", sType: "string", sTitle: "Duyuru Sahibi" },
                {
                    mData: "CreatedTime", sType: "date", sTitle: "Duyuru Tarihi",
                    render: function (data, type, row) {
                        if (data != null) {
                            var datetime = new Date(data.toString())
                            datetime.setHours(datetime.getHours() + 3)

                            return datetime.toISOString().substr(0, 16).replace('T', ' ');
                        }
                        else { return ''; }
                    }
                },

                {
                    mData: "Level", sType: "string", sTitle: "Önem Derecesi",
                    render: function (data) {
                        if (data != null) {
                            if (data == 'D') {
                                return 'Düşük';
                            }
                            else if (data == 'N') {
                                return 'Normal';
                            } else if (data == 'Y') {
                                return 'Yüksek';
                            } else {
                                return '-'
                            }
                        }
                    }
                },
                {
                    mData: "Type", sType: "string", sTitle: "Duyuru Tipi",
                    render: function (data) {
                        if (data != null) {
                            if (data == 'A') {
                                return 'Duyuru';
                            }
                            else if (data == 'I') {
                                return 'Bilgilendirme';
                            } else if (data == 'C') {
                                return 'İpucu';
                            }
                            else if (data == 'G') {
                                return 'Klavuz';
                            } else {
                                return '-'
                            }
                        }
                    }
                },
                { mData: "Subject", sType: "string", sTitle: "Konu" },
                { mData: "Description", sType: "string", sTitle: "Duyuru Metni" },
                { mData: "DeletedTime", sType: "date", sTitle: "Silinme Tarihi" ,visible:false},

                // { mData: "DepartmentId", sType: "string", sTitle: "Bilgi Verilen Departman" }

            ];
            self.createTable(listAnnouncement);
            $("#announcementTable tbody").on("dblclick", "tr", function () {
                var data = self.dataTable.row(this).data();
                self.dblclick(data.Id);
            });

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
</style>