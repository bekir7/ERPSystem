<script>
import { layoutComputed } from "@/state/helpers";
import { SimpleBar } from "simplebar-vue3";

export default {
  components: {
    SimpleBar,
  },
  data() {
    return {
      settings: {
        minScrollbarLength: 60,
      },
    };
  },
  computed: {
    ...layoutComputed,
    layoutType: {
      get() {
        return this.$store ? this.$store.state.layout.layoutType : {} || {};
      },
    },
  },

  watch: {
    $route: {
      handler: "onRoutechange",
      immediate: true,
      deep: true,
    },
  },

  mounted() {
    if (document.querySelectorAll(".navbar-nav .collapse")) {
      let collapses = document.querySelectorAll(".navbar-nav .collapse");
      collapses.forEach((collapse) => {
        // Hide sibling collapses on `show.bs.collapse`
        collapse.addEventListener("show.bs.collapse", (e) => {
          e.stopPropagation();
          let closestCollapse = collapse.parentElement.closest(".collapse");
          if (closestCollapse) {
            let siblingCollapses =
              closestCollapse.querySelectorAll(".collapse");
            siblingCollapses.forEach((siblingCollapse) => {
              if (siblingCollapse.classList.contains("show")) {
                let aChild = siblingCollapse.parentNode.firstChild;
                if (aChild.hasAttribute("aria-expanded")) {
                  aChild.setAttribute("aria-expanded", "false");
                }
                siblingCollapse.classList.remove("show");
              }
            });
          } else {
            let getSiblings = (elem) => {
              // Setup siblings array and get the first sibling
              let siblings = [];
              let sibling = elem.parentNode.firstChild;
              // Loop through each sibling and push to the array
              while (sibling) {
                if (sibling.nodeType === 1 && sibling !== elem) {
                  siblings.push(sibling);
                }
                sibling = sibling.nextSibling;
              }
              return siblings;
            };
            let siblings = getSiblings(collapse.parentElement);
            siblings.forEach((item) => {
              if (item.childNodes.length > 2)
                item.firstElementChild.setAttribute("aria-expanded", "false");
              let ids = item.querySelectorAll("*[id]");
              ids.forEach((item1) => {
                let aChild = item1.parentNode.firstChild;
                if (aChild.hasAttribute("aria-expanded")) {
                  aChild.setAttribute("aria-expanded", "false");
                }
                item1.classList.remove("show");
                if (item1.childNodes.length > 2) {
                  let val = item1.querySelectorAll("ul li a");

                  val.forEach((subitem) => {
                    if (subitem.hasAttribute("aria-expanded"))
                      subitem.setAttribute("aria-expanded", "false");
                  });
                }
              });
            });
          }
        });

        // Hide nested collapses on `hide.bs.collapse`
        collapse.addEventListener("hide.bs.collapse", (e) => {
          e.stopPropagation();
          let childCollapses = collapse.querySelectorAll(".collapse");
          childCollapses.forEach((childCollapse) => {
            let childCollapseInstance = childCollapse;
            childCollapseInstance.hide();
          });
        });
      });
    }
  },

  methods: {
    onRoutechange(ele) {
      this.initActiveMenu(ele.path);
      if (document.getElementsByClassName("mm-active").length > 0) {
        const currentPosition =
          document.getElementsByClassName("mm-active")[0].offsetTop;
        if (currentPosition > 500)
          if (this.$refs.isSimplebar)
            this.$refs.isSimplebar.value.getScrollElement().scrollTop =
              currentPosition + 300;
      }
    },

    initActiveMenu(ele) {
      setTimeout(() => {
        if (document.querySelector("#navbar-nav")) {
          let a = document
            .querySelector("#navbar-nav")
            .querySelector('[href="' + ele + '"]');

          if (a) {
            a.classList.add("active");
            let parentCollapseDiv = a.closest(".collapse.menu-dropdown");
            if (parentCollapseDiv) {
              parentCollapseDiv.classList.add("show");
              parentCollapseDiv.parentElement.children[0].classList.add(
                "active"
              );
              parentCollapseDiv.parentElement.children[0].setAttribute(
                "aria-expanded",
                "true"
              );
              if (
                parentCollapseDiv.parentElement.closest(
                  ".collapse.menu-dropdown"
                )
              ) {
                parentCollapseDiv.parentElement
                  .closest(".collapse")
                  .classList.add("show");
                if (
                  parentCollapseDiv.parentElement.closest(".collapse")
                    .previousElementSibling
                )
                  parentCollapseDiv.parentElement
                    .closest(".collapse")
                    .previousElementSibling.classList.add("active");
              }
            }
          }
        }
      }, 0);
    },
  },
};
</script>

<template>
  <div class="container-fluid">
    <div id="two-column-menu"></div>

    <template v-if="layoutType === 'twocolumn'">
      <SimpleBar class="navbar-nav" id="navbar-nav">
        <li class="menu-title">
          <span data-key="t-menu"> {{ $t("t-menu") }}</span>
        </li>
        <li class="nav-item">
          <a
            class="nav-link menu-link"
            href="#sidebarDashboards"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarDashboards"
          >
            <i class="ri-dashboard-2-line"></i>
            <span data-key="t-dashboard"> {{ $t("t-dashboard") }}</span>
          </a>
          <div class="collapse menu-dropdown" id="sidebarDashboards">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">
                <router-link
                  to="/"
                  class="nav-link custom-abc"
                  data-key="t-my-page"
                >
                  {{ $t("t-my-page") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end Dashboard Menu -->
        <li class="nav-item">
          <a
            class="nav-link menu-link"
            href="#sidebarInformationTechnologies"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarInformationTechnologies"
          >
            <i class="ri-macbook-line"></i>
            <span data-key="t-information-technologies-rd">
              {{ $t("t-information-technologies-rd") }}</span
            >
          </a>
          <div
            class="collapse menu-dropdown"
            id="sidebarInformationTechnologies"
          >
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">
                <a
                  href="#sidebarServiceManagement"
                  class="nav-link"
                  data-bs-toggle="collapse"
                  role="button"
                  aria-expanded="false"
                  aria-controls="sidebarServiceManagement"
                  data-key="t-service-management"
                >
                  {{ $t("t-service-management") }}
                </a>
                <div
                  class="collapse menu-dropdown"
                  id="sidebarServiceManagement"
                >
                  <ul class="nav nav-sm flex-column">
                    <li class="nav-item">
                      <router-link
                        to="/btandrnd/information-technologies-rd/service-management/fault-management"
                        class="nav-link"
                        data-key="t-fault-management"
                      >
                        {{ $t("t-fault-management") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/btandrnd/information-technologies-rd/service-management/inventory-management"
                        class="nav-link"
                        data-key="t-inventory-management"
                      >
                        {{ $t("t-inventory-management") }}
                      </router-link>
                    </li>
                    <li class="nav-item">
                      <router-link
                        to="/btandrnd/information-technologies-rd/service-management/data-base"
                        class="nav-link"
                        data-key="t-data-base"
                      >
                        {{ $t("t-data-base") }}
                      </router-link>
                    </li>
                    <li class="nav-item">
                      <router-link
                        to="/btandrnd/information-technologies-rd/service-management/risk-management"
                        class="nav-link"
                        data-key="t-risk-management"
                      >
                        {{ $t("t-risk-management") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/btandrnd/information-technologies-rd/service-management/compatibility"
                        class="nav-link"
                        data-key="t-compatibility"
                      >                        {{ $t("t-compatibility") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/btandrnd/information-technologies-rd/service-management/admin-panel"
                        class="nav-link"
                        data-key="t-admin-panel"
                      >
                        {{ $t("t-admin-panel") }}
                      </router-link>
                    </li>
                  </ul>
                </div>
              </li>
              <li class="nav-item">

                <router-link
                  to="/btandrnd/information-technologies-rd/project-management"
                  class="nav-link"
                  data-key="t-project-management"
                >
                  {{ $t("t-project-management") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end Bt Menu -->
        <li class="nav-item">
          <a class="nav-link menu-link" href="#sidebarHumanResources" data-bs-toggle="collapse" role="button"
            aria-expanded="false" aria-controls="sidebarHumanResources">
            <i class="ri-account-circle-line"></i>
            <span data-key="t-human-resources">
              {{ $t("t-human-resources") }}</span>
          </a>
          <div class="collapse menu-dropdown" id="sidebarHumanResources">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">

                <a
                  href="#sidebarKVKKProcesses"
                  class="nav-link"
                  data-bs-toggle="collapse"
                  role="button"
                  aria-expanded="false"
                  aria-controls="sidebarKVKKProcesses"
                  data-key="t-kvkk-processes"
                >
                  {{ $t("t-kvkk-processes") }}
                </a>
                <div class="collapse menu-dropdown" id="sidebarKVKKProcesses">
                  <ul class="nav nav-sm flex-column">
                    <li class="nav-item">
                      <router-link
                        to="/btandrnd/information-technologies-rd/kvkk-processes/it-system-access-process"
                        class="nav-link"
                        data-key="t-it-system-access-process"
                      >
                        {{ $t("t-it-system-access-process") }}
                      </router-link>
                    </li>
                    <li class="nav-item">
                      <router-link
                        to="/btandrnd/information-technologies-rd/kvkk-processes/change-management"
                        class="nav-link"
                        data-key="t-change-management"
                      >
                        {{ $t("t-change-management") }}
                      </router-link>
                    </li>
                  </ul>
                </div>
              </li>
              <li class="nav-item">
                <router-link
                  to="/btandrnd/information-technologies-rd/information-security"
                  class="nav-link"
                  data-key="t-information-security"
                >
                  {{ $t("t-information-security") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end Bt Menu -->
        <li class="nav-item">
          <a
            class="nav-link menu-link"
            href="#sidebarHumanResources"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarHumanResources"
          >
            <i class="ri-account-circle-line"></i>
            <span data-key="t-human-resources">
              {{ $t("t-human-resources") }}</span
            >
          </a>
          <div class="collapse menu-dropdown" id="sidebarHumanResources">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">
                <a
                  href="#sidebarPersonnelManagement"
                  class="nav-link"
                  data-bs-toggle="collapse"
                  role="button"
                  aria-expanded="false"
                  aria-controls="sidebarPersonnelManagement"
                  data-key="t-personnel-management-process"
                >
                  {{ $t("t-personnel-management-process") }}
                </a>
                <div
                  class="collapse menu-dropdown"
                  id="sidebarPersonnelManagement"
                >
                  <ul class="nav nav-sm flex-column">
                    <li class="nav-item">
                      <router-link
                        to="/other/human-resources/personnel-management/personnel-request-process"
                        class="nav-link"
                        data-key="t-personnel-demand"
                      >
>>>>>>> ebrartep
                        {{ $t("t-personnel-demand") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/other/human-resources/personnel-management/selection-and-placement-form"
                        class="nav-link"
                        data-key="t-selection-and-placement-form"
                      >
                        {{ $t("t-selection-and-placement-form") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/other/human-resources/personnel-management/pre-job-preparation"
                        class="nav-link"
                        data-key="t-pre-job-preparation"
                      >
                        {{ $t("t-pre-job-preparation") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/other/human-resources/personnel-management/recruitment-process"
                        class="nav-link"
                        data-key="t-recruitment-process"
                      >
                        {{ $t("t-recruitment-process") }}
                      </router-link>
                    </li>
                    <li class="nav-item">
                      <router-link
                        to="/other/human-resources/personnel-management/recruitment-announcement-process"
                        class="nav-link"
                        data-key="t-recruitment-announcement-process"
                      >
                        {{ $t("t-recruitment-announcement-process") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/other/human-resources/personnel-management/two-to-six-month-evaluation"
                        class="nav-link"
                        data-key="t-two-to-six-months-evaluation-process"
                      >
                        {{ $t("t-two-to-six-months-evaluation-process") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/other/human-resources/personnel-management/feedback-form-from-alisan"
                        class="nav-link"
                        data-key="t-feedback-form-from-alisan"
                      >
                        {{ $t("t-feedback-form-from-alisan") }}
                      </router-link>
                    </li>
                  </ul>
                </div>
              </li>
              <li class="nav-item">

                <a
                  href="#sidebarEducationProcess"
                  class="nav-link"
                  data-bs-toggle="collapse"
                  role="button"
                  aria-expanded="false"
                  aria-controls="sidebarEducationProcess"
                  data-key="t-education-process"
                >
                  {{ $t("t-education-process") }}
                </a>
                <div
                  class="collapse menu-dropdown"
                  id="sidebarEducationProcess"
                >
                  <ul class="nav nav-sm flex-column">
                    <!--Eğitim Sürecleri-->
                  </ul>
                </div>
              </li>
              <li class="nav-item">

                <a
                  href="#sidebarPersonnelAffairs"
                  class="nav-link"
                  data-bs-toggle="collapse"
                  role="button"
                  aria-expanded="false"
                  aria-controls="sidebarPersonnelAffairs"
                  data-key="t-personnel-affairs"
                >
                  {{ $t("t-personnel-affairs") }}
                </a>
                <div
                  class="collapse menu-dropdown"
                  id="sidebarPersonnelAffairs"
                >
                  <ul class="nav nav-sm flex-column">
                    <li class="nav-item">
                      <router-link
                        to="/other/human-resources/personnel-affairs/overtime-process"
                        class="nav-link"
                        data-key="t-overtime-process"
                      >
                        {{ $t("t-overtime-process") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/other/human-resources/personnel-affairs/cost-advance-process"
                        class="nav-link"
                        data-key="t-cost-advance-process"
                      >
                        {{ $t("t-cost-advance-process") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/other/human-resources/personnel-affairs/permission-process"
                        class="nav-link"
                        data-key="t-permission-process"
                      >
                        {{ $t("t-permission-process") }}
                      </router-link>
                    </li>
                  </ul>
                </div>
              </li>
              <li class="nav-item">

                <a
                  href="#sidebarPerformanceManagement"
                  class="nav-link"
                  data-bs-toggle="collapse"
                  role="button"
                  aria-expanded="false"
                  aria-controls="sidebarPerformanceManagement"
                  data-key="t-performance-management"
                >
                  {{ $t("t-performance-management") }}
                </a>
                <div
                  class="collapse menu-dropdown"
                  id="sidebarPerformanceManagement"
                >
                  <ul class="nav nav-sm flex-column">
                    <!--Performans Sürecleri-->
                  </ul>
                </div>
              </li>
            </ul>
          </div>
        </li>
        <!-- end HR Menu -->
        <li class="nav-item">

          <a
            class="nav-link menu-link"
            href="#sidebarManagement"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarManagement"
          >
            <i class="ri-group-line"></i>
            <span data-key="t-management-systems-projects">
              {{ $t("t-management-systems-projects") }}</span
            >
          </a>
          <div class="collapse menu-dropdown" id="sidebarManagement">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">

                <router-link
                  to="/other/management-systems-projects/customer-complaint-process"
                  class="nav-link"
                  data-key="t-customer-complaint-process"
                >
                  {{ $t("t-customer-complaint-process") }}
                </router-link>
              </li>
              <li class="nav-item">

                <router-link
                  to="/other/management-systems-projects/customer-complaint-process"
                  class="nav-link"
                  data-key="t-internal-customer-complaint-process"
                >
                  {{ $t("t-internal-customer-complaint-process") }}
                </router-link>
              </li>
              <li class="nav-item">

                <router-link
                  to="/other/management-systems-projects/corrective-action-form-process"
                  class="nav-link"
                  data-key="t-corrective-action-form-process"
                >
                  {{ $t("t-corrective-action-form-process") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end MSP Menu -->
        <li class="nav-item">

          <a
            class="nav-link menu-link"
            href="#sidebarAdministrativeAffairs"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarAdministrativeAffairs"
          >
            <i class="ri-folder-4-line"></i>
            <span data-key="t-administrative-affairs">
              {{ $t("t-administrative-affairs") }}</span
            >
          </a>
          <div class="collapse menu-dropdown" id="sidebarAdministrativeAffairs">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">
                <router-link
                  to="/other/administrative-affairs/incoming-document-management-process"
                  class="nav-link"
                  data-key="t-incoming-document-management-process"
                >
                  {{ $t("t-incoming-document-management-process") }}
                </router-link>
              </li>
              <li class="nav-item">

                <router-link
                  to="/other/administrative-affairs/line-tracking-process"
                  class="nav-link"
                  data-key="t-line-tracking-process"
                >
                  {{ $t("t-line-tracking-process") }}
                </router-link>
              </li>
              <li class="nav-item">

                <router-link
                  to="/other/administrative-affairs/vehicle-information-form"
                  class="nav-link"
                  data-key="t-vehicle-information-form"
                >
                  {{ $t("t-vehicle-information-form") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end AF Menu -->
        <li class="nav-item">

          <a
            class="nav-link menu-link"
            href="#sidebarAccounting"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarAccounting"
          >
            <i class="ri-funds-box-line"></i>
            <span data-key="t-financial-affairs">
              {{ $t("t-financial-affairs") }}</span
            >
          </a>
          <div class="collapse menu-dropdown" id="sidebarAccounting">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">

                <router-link
                  to="/other/financial-affairs/budget-data-entry-screen"
                  class="nav-link"
                  data-key="t-budget-data-entry-screen"
                >
                  {{ $t("t-budget-data-entry-screen") }}
                </router-link>
              </li>

              <li class="nav-item">
                <router-link
                  to="/other/financial-affairs/physical-document-tracking-system"
                  class="nav-link"
                  data-key="t-physical-document-tracking-system"
                >
                  {{ $t("t-physical-document-tracking-system") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end Accounting Menu -->
        <li class="nav-item">
          <a
            class="nav-link menu-link"
            href="#sidebarPurchasing"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarPurchasing"
          >
            <i class="ri-shopping-cart-line"></i>
            <span data-key="t-buy-systems"> {{ $t("t-buy-systems") }}</span>
          </a>
          <div class="collapse menu-dropdown" id="sidebarPurchasing">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">
                <router-link
                  to="/buy/buy-system"
                  class="nav-link"
                  data-key="t-purchasing-system"
                >
                  {{ $t("t-purchasing-system") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end Buy Menu -->
        <li class="nav-item">
          <a
            class="nav-link menu-link"
            href="#sidebarInsurance"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarInsurance"
          >
            <i class="ri-hand-coin-line"></i>
            <span data-key="t-insurance"> {{ $t("t-insurance") }}</span>
          </a>
          <div class="collapse menu-dropdown" id="sidebarInsurance">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">
                <router-link
                  to="/other/insurance/damage-insurance-transactions"
                  class="nav-link"
                  data-key="t-damage-insurance-transactions"
                >
                  {{ $t("t-damage-insurance-transactions") }}
                </router-link>
              </li>
              <li class="nav-item">
                <router-link
                  to="/other/insurance/damage-insurance-notification-process"
                  class="nav-link"
                  data-key="t-damage-insurance-notification-process"
                >
                  {{ $t("t-damage-insurance-notification-process") }}
                </router-link>
              </li>
              <li class="nav-item">
                <router-link
                  to="/other/insurance/damage-insurance-user-transactions"
                  class="nav-link"
                  data-key="t-damage-insurance-user-transactions"
                >
                  {{ $t("t-damage-insurance-user-transactions") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end Insurance Menu -->
        <li class="nav-item">
          <a
            class="nav-link menu-link"
            href="#sidebarLaw"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarLaw"
          >
            <i class="ri-scales-line"></i>
            <span data-key="t-law"> {{ $t("t-law") }}</span>
          </a>
          <div class="collapse menu-dropdown" id="sidebarLaw">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">
                <router-link to="/btandrnd/law-systems/law-process/law-accept" class="nav-link" data-key="t-law">
                  {{ $t("t-law") }}
                </router-link>
              </li>
              <li class="nav-item">
                <router-link to="/btandrnd/law-systems/law-process/law-accept2" class="nav-link" data-key="Duruşma">
                  {{ $t("Duruşma Saat Ekle") }}
                </router-link>
              </li>
              <li class="nav-item">
                <router-link to="/btandrnd/law-systems/law-process/law-result" class="nav-link" data-key="Dava Yönetimi">
                  {{ $t("Sonuçlanan Davalar") }}
                </router-link>
              </li>
              <li class="nav-item">
                <router-link to="/btandrnd/law-systems/law-process/law-yonetici" class="nav-link" data-key="Duruşma Saati">
                  {{ $t("Dava Yönetimi") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end Law Menu -->
      </SimpleBar>
    </template>

    <template v-else>
      <ul class="navbar-nav h-100" id="navbar-nav">
        <li class="menu-title">
          <span data-key="t-menu"> {{ $t("t-menu") }}</span>
        </li>
        <li class="nav-item">
          <a
            class="nav-link menu-link"
            href="#sidebarDashboards"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarDashboards"
          >
            <i class="ri-dashboard-2-line"></i>
            <span data-key="t-dashboard"> {{ $t("t-dashboard") }}</span>
          </a>
          <div class="collapse menu-dropdown" id="sidebarDashboards">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">

                <router-link
                  to="/"
                  class="nav-link custom-abc"
                  data-key="t-my-page"
                >
                  {{ $t("t-my-page") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end Dashboard Menu -->
        <li class="nav-item">

          <a
            class="nav-link menu-link"
            href="#sidebarInformationTechnologies"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarInformationTechnologies"
          >
            <i class="ri-macbook-line"></i>
            <span data-key="t-information-technologies-rd">
              {{ $t("t-information-technologies-rd") }}</span
            >
          </a>
          <div
            class="collapse menu-dropdown"
            id="sidebarInformationTechnologies"
          >
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">
                <a
                  href="#sidebarServiceManagement"
                  class="nav-link"
                  data-bs-toggle="collapse"
                  role="button"
                  aria-expanded="false"
                  aria-controls="sidebarServiceManagement"
                  data-key="t-service-management"
                >
                  {{ $t("t-service-management") }}
                </a>
                <div
                  class="collapse menu-dropdown"
                  id="sidebarServiceManagement"
                >
                  <ul class="nav nav-sm flex-column">
                    <li class="nav-item">
                      <router-link
                        to="/btandrnd/information-technologies-rd/service-management/fault-management"
                        class="nav-link"
                        data-key="t-fault-management"
                      >
                        {{ $t("t-fault-management") }}
                      </router-link>
                    </li>
                    <li class="nav-item">
                      <router-link
                        to="/btandrnd/information-technologies-rd/service-management/change-management"
                        class="nav-link"
                        data-key="t-change-management"
                      >
                        {{ $t("t-change-management") }}
                      </router-link>
                    </li>
                    <li class="nav-item">
                      <router-link
                        to="/btandrnd/information-technologies-rd/service-management/inventory-management"
                        class="nav-link"
                        data-key="t-inventory-management"
                      >
                        {{ $t("t-inventory-management") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/btandrnd/information-technologies-rd/service-management/data-base"
                        class="nav-link"
                        data-key="t-data-base"
                      >
                        {{ $t("t-data-base") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/btandrnd/information-technologies-rd/service-management/risk-management"
                        class="nav-link"
                        data-key="t-risk-management"
                      >
                        {{ $t("t-risk-management") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/btandrnd/information-technologies-rd/service-management/compatilibity"
                        class="nav-link"
                        data-key="t-compatibility"
                      >
                        {{ $t("t-compatibility") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/btandrnd/information-technologies-rd/service-management/admin-panel"
                        class="nav-link"
                        data-key="t-admin-panel"
                      >
                        {{ $t("t-admin-panel") }}
                      </router-link>
                    </li>
                  </ul>
                </div>
              </li>
              <li class="nav-item">
                <router-link
                  to="/btandrnd/information-technologies-rd/project-management"
                  class="nav-link"
                  data-key="t-project-management"
                >
                  {{ $t("t-project-management") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end Bt Menu -->
        <li class="nav-item">

          <a
            class="nav-link menu-link"
            href="#sidebarHumanResources"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarHumanResources"
          >
            <i class="ri-account-circle-line"></i>
            <span data-key="t-human-resources">
              {{ $t("t-human-resources") }}</span
            >
          </a>
          <div class="collapse menu-dropdown" id="sidebarHumanResources">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">

                <a
                  href="#sidebarPersonnelManagement"
                  class="nav-link"
                  data-bs-toggle="collapse"
                  role="button"
                  aria-expanded="false"
                  aria-controls="sidebarPersonnelManagement"
                  data-key="t-personnel-management-process"
                >
                  {{ $t("t-personnel-management-process") }}
                </a>
                <div
                  class="collapse menu-dropdown"
                  id="sidebarPersonnelManagement"
                >
                  <ul class="nav nav-sm flex-column">
                    <li class="nav-item">
                      <router-link
                        to="/other/human-resources/personnel-management/personnel-request-process"
                        class="nav-link"
                        data-key="t-personnel-demand"
                      >
                        {{ $t("t-personnel-demand") }}
                      </router-link>
                    </li>
                    <li class="nav-item">
                      <router-link
                        to="/other/human-resources/personnel-management/selection-and-placement-form"
                        class="nav-link"
                        data-key="t-selection-and-placement-form"
                      >
                        {{ $t("t-selection-and-placement-form") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/other/human-resources/personnel-management/pre-job-preparation"
                        class="nav-link"
                        data-key="t-pre-job-preparation"
                      >
                        {{ $t("t-pre-job-preparation") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/other/human-resources/personnel-management/recruitment-process"
                        class="nav-link"
                        data-key="t-recruitment-process"
                      >
                        {{ $t("t-recruitment-process") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/other/human-resources/personnel-management/recruitment-announcement-process"
                        class="nav-link"
                        data-key="t-recruitment-announcement-process"
                      >

                        {{ $t("t-recruitment-announcement-process") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/other/human-resources/personnel-management/two-to-six-month-evaluation"
                        class="nav-link"
                        data-key="t-two-to-six-months-evaluation-process"
                      >

                        {{ $t("t-two-to-six-months-evaluation-process") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/other/human-resources/personnel-management/feedback-form-from-alisan"
                        class="nav-link"
                        data-key="t-feedback-form-from-alisan"
                      >
                        {{ $t("t-feedback-form-from-alisan") }}
                      </router-link>
                    </li>
                  </ul>
                </div>
              </li>
              <li class="nav-item">

                <a
                  href="#sidebarEducationProcess"
                  class="nav-link"
                  data-bs-toggle="collapse"
                  role="button"
                  aria-expanded="false"
                  aria-controls="sidebarEducationProcess"
                  data-key="t-education-process"
                >
                  {{ $t("t-education-process") }}
                </a>
                <div
                  class="collapse menu-dropdown"
                  id="sidebarEducationProcess"
                >
                  <ul class="nav nav-sm flex-column">
                    <!--Eğitim Sürecleri-->
                  </ul>
                </div>
              </li>
              <li class="nav-item">

                <a
                  href="#sidebarPersonnelAffairs"
                  class="nav-link"
                  data-bs-toggle="collapse"
                  role="button"
                  aria-expanded="false"
                  aria-controls="sidebarPersonnelAffairs"
                  data-key="t-personnel-affairs"
                >
                  {{ $t("t-personnel-affairs") }}
                </a>
                <div
                  class="collapse menu-dropdown"
                  id="sidebarPersonnelAffairs"
                >
                  <ul class="nav nav-sm flex-column">
                    <li class="nav-item">
                      <router-link
                        to="/other/human-resources/personnel-affairs/overtime-process"
                        class="nav-link"
                        data-key="t-overtime-process"
                      >
                        {{ $t("t-overtime-process") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/other/human-resources/personnel-affairs/cost-advance-process"
                        class="nav-link"
                        data-key="t-cost-advance-process"
                      >
                        {{ $t("t-cost-advance-process") }}
                      </router-link>
                    </li>
                    <li class="nav-item">

                      <router-link
                        to="/other/human-resources/personnel-affairs/permission-process"
                        class="nav-link"
                        data-key="t-permission-process"
                      >
                        {{ $t("t-permission-process") }}
                      </router-link>
                    </li>
                  </ul>
                </div>
              </li>
              <li class="nav-item">

                <a
                  href="#sidebarPerformanceManagement"
                  class="nav-link"
                  data-bs-toggle="collapse"
                  role="button"
                  aria-expanded="false"
                  aria-controls="sidebarPerformanceManagement"
                  data-key="t-performance-management"
                >
                  {{ $t("t-performance-management") }}
                </a>
                <div
                  class="collapse menu-dropdown"
                  id="sidebarPerformanceManagement"
                >
                  <ul class="nav nav-sm flex-column">
                    <!--Performans Sürecleri-->
                  </ul>
                </div>
              </li>
            </ul>
          </div>
        </li>
        <!-- end HR Menu -->
        <li class="nav-item">
          <a
            class="nav-link menu-link"
            href="#sidebarManagement"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarManagement"
          >
            <i class="ri-group-line"></i>
            <span data-key="t-management-systems-projects">
              {{ $t("t-management-systems-projects") }}</span
            >
          </a>
          <div class="collapse menu-dropdown" id="sidebarManagement">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">

                <router-link
                  to="/other/management-systems-projects/customer-complaint-process"
                  class="nav-link"
                  data-key="t-customer-complaint-process"
                >
                  {{ $t("t-customer-complaint-process") }}
                </router-link>
              </li>
              <li class="nav-item">

                <router-link
                  to="/other/management-systems-projects/customer-complaint-process"
                  class="nav-link"
                  data-key="t-internal-customer-complaint-process"
                >                  {{ $t("t-internal-customer-complaint-process") }}
                </router-link>
              </li>
              <li class="nav-item">

                <router-link
                  to="/other/management-systems-projects/corrective-action-form-process"
                  class="nav-link"
                  data-key="t-corrective-action-form-process"
                >
                  {{ $t("t-corrective-action-form-process") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end MSP Menu -->
        <li class="nav-item">

          <a
            class="nav-link menu-link"
            href="#sidebarAdministrativeAffairs"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarAdministrativeAffairs"
          >
            <i class="ri-folder-4-line"></i>
            <span data-key="t-administrative-affairs">
              {{ $t("t-administrative-affairs") }}</span
            >
          </a>
          <div class="collapse menu-dropdown" id="sidebarAdministrativeAffairs">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">

                <router-link
                  to="/other/administrative-affairs/incoming-document-management-process"
                  class="nav-link"
                  data-key="t-incoming-document-management-process"
                >
                  {{ $t("t-incoming-document-management-process") }}
                </router-link>
              </li>
              <li class="nav-item">

                <router-link
                  to="/other/administrative-affairs/line-tracking-process"
                  class="nav-link"
                  data-key="t-line-tracking-process"
                >
                  {{ $t("t-line-tracking-process") }}
                </router-link>
              </li>
              <li class="nav-item">

                <router-link
                  to="/other/administrative-affairs/vehicle-information-form"
                  class="nav-link"
                  data-key="t-vehicle-information-form"
                >
                  {{ $t("t-vehicle-information-form") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end AF Menu -->
        <li class="nav-item">
          <a
            class="nav-link menu-link"
            href="#sidebarAccounting"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarAccounting"
          >
            <i class="ri-funds-box-line"></i>
            <span data-key="t-financial-affairs">
              {{ $t("t-financial-affairs") }}</span
            >
          </a>
          <div class="collapse menu-dropdown" id="sidebarAccounting">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">

                <router-link
                  to="/other/financial-affairs/budget-data-entry-screen"
                  class="nav-link"
                  data-key="t-budget-data-entry-screen"
                >
                  {{ $t("t-budget-data-entry-screen") }}
                </router-link>
              </li>

              <li class="nav-item">

                <router-link
                  to="/other/financialAffairs/physical-document-tracking-system"
                  class="nav-link"
                  data-key="t-physical-document-tracking-system"
                >
                  {{ $t("t-physical-document-tracking-system") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end Accounting Menu -->
        <li class="nav-item">
          <a
            class="nav-link menu-link"
            href="#sidebarPurchasing"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarPurchasing"
          >
            <i class="ri-shopping-cart-line"></i>
            <span data-key="t-buy-systems"> {{ $t("t-buy-systems") }}</span>
          </a>
          <div class="collapse menu-dropdown" id="sidebarPurchasing">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">

                <router-link
                  to="/buy/buy-system"
                  class="nav-link"
                  data-key="t-purchasing-system"
                >
                  {{ $t("t-purchasing-system") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end Buy Menu -->
        <li class="nav-item">

          <a
            class="nav-link menu-link"
            href="#sidebarInsurance"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarInsurance">
                  <i class="ri-hand-coin-line"></i>
            <span data-key="t-insurance"> {{ $t("t-insurance") }}</span>
          </a>
          <div class="collapse menu-dropdown" id="sidebarInsurance">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">

                <router-link
                  to="/other/insurance/damage-insurance-transactions"
                  class="nav-link"
                  data-key="t-damage-insurance-transactions"
                >
                  {{ $t("t-damage-insurance-transactions") }}
                </router-link>
              </li>
              <li class="nav-item">

                <router-link
                  to="/other/insurance/damage-insurance-notification-process"
                  class="nav-link"
                  data-key="t-damage-insurance-notification-process"
                >
                  {{ $t("t-damage-insurance-notification-process") }}
                </router-link>
              </li>
              <li class="nav-item">

                <router-link
                  to="/other/insurance/damage-insurance-user-transactions"
                  class="nav-link"
                  data-key="t-damage-insurance-user-transactions"
                >
                  {{ $t("t-damage-insurance-user-transactions") }}
                </router-link>
              </li>
            </ul>
          </div>
        </li>
        <!-- end Insurance Menu -->
        <li class="nav-item">

          <a
            class="nav-link menu-link"
            href="#sidebarLaw"
            data-bs-toggle="collapse"
            role="button"
            aria-expanded="false"
            aria-controls="sidebarLaw"
          >
            <i class="ri-scales-line"></i>
            <span data-key="t-law"> {{ $t("t-law") }}</span>
          </a>
          <div class="collapse menu-dropdown" id="sidebarLaw">
            <ul class="nav nav-sm flex-column">
              <li class="nav-item">
                <router-link to="/other/law" class="nav-link" data-key="t-law">
                  {{ $t("t-law") }}
                </router-link>
              </li>

            </ul>
          </div>
        </li>
        <!-- end Law Menu -->
      </ul>
    </template>
  </div>
  <!-- Sidebar -->
</template>
