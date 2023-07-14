<script>
  import router from "@/router";
  import {SimpleBar}  from "simplebar-vue3";
  import { layoutComputed } from "@/state/helpers";
  import Menu from "@/components/menu.vue";
  import NavBar from "@/components/nav-bar";
  import RightBar from "@/components/right-bar";
  import Footer from "@/components/footer";
  
  /**
   * 
   * Vertical layout
   */
  export default {
    components: {
      NavBar,
      RightBar,
      Footer,
      SimpleBar,
      Menu,
    },
    data() {
      return {
        isMenuCondensed: false,
        rmenu: localStorage.getItem("rmenu") ? localStorage.getItem("rmenu") : "twocolumn",
      };
    },
  
    computed: {
      ...layoutComputed,
    },
    created: () => {
      document.body.removeAttribute("data-layout", "horizontal");
      document.body.removeAttribute("data-topbar", "dark");
      document.body.removeAttribute("data-layout-size", "boxed");
    },
    methods: {
      initActiveMenu() {
        const pathName = window.location.pathname;
        const ul = document.getElementById("navbar-nav");
        if (ul) {
          const items = Array.from(ul.querySelectorAll("a.nav-link"));
          let activeItems = items.filter((x) => x.classList.contains("active"));
          this.removeActivation(activeItems);
          let matchingMenuItem = items.find((x) => {
            return x.getAttribute("href") === pathName;
          });
          if (matchingMenuItem) {
            this.activateParentDropdown(matchingMenuItem);
          } else {
            var id = pathName.replace("/", "");
            if (id) document.body.classList.add("twocolumn-panel");
            this.activateIconSidebarActive(pathName);
          }
        }
      },
  
      updateMenu(e) {
        document.body.classList.remove("twocolumn-panel");
        const ul = document.getElementById("navbar-nav");
        if (ul) {
          const items = Array.from(ul.querySelectorAll(".show"));
          items.forEach((item) => {
            item.classList.remove("show");
          });
        }
        const icons = document.getElementById("two-column-menu");
        if (icons) {
          const activeIcons = Array.from(icons.querySelectorAll(".nav-icon.active"));
          activeIcons.forEach((item) => {
            item.classList.remove("active");
          });
        }
        document.getElementById(e).classList.add("show");
        this.activateIconSidebarActive("#" + e);
      },
  
      removeActivation(items) {
        items.forEach((item) => {
          if (item.classList.contains("menu-link")) {
            if (!item.classList.contains("active")) {
              item.setAttribute("aria-expanded", false);
            }
            item.nextElementSibling.classList.remove("show");
          }
          if (item.classList.contains("nav-link")) {
            if (item.nextElementSibling) {
              item.nextElementSibling.classList.remove("show");
            }
            item.setAttribute("aria-expanded", false);
          }
          item.classList.remove("active");
        });
      },
  
      activateIconSidebarActive(id) {
        var menu = document.querySelector(
          "#two-column-menu .simplebar-content-wrapper a[href='" + id + "'].nav-icon"
        );
        if (menu !== null) {
          menu.classList.add("active");
        }
      },
  
      activateParentDropdown(item) {
        // navbar-nav menu add active
        item.classList.add("active");
        let parentCollapseDiv = item.closest(".collapse.menu-dropdown");
        if (parentCollapseDiv) {
          // to set aria expand true remaining
          parentCollapseDiv.classList.add("show");
          parentCollapseDiv.parentElement.children[0].classList.add("active");
          parentCollapseDiv.parentElement.children[0].setAttribute("aria-expanded", "true");
          if (parentCollapseDiv.parentElement.closest(".collapse.menu-dropdown")) {
            this.activateIconSidebarActive(
              "#" +
                parentCollapseDiv.parentElement
                  .closest(".collapse.menu-dropdown")
                  .getAttribute("id")
            );
            parentCollapseDiv.parentElement.closest(".collapse").classList.add("show");
            if (parentCollapseDiv.parentElement.closest(".collapse").previousElementSibling)
              parentCollapseDiv.parentElement
                .closest(".collapse")
                .previousElementSibling.classList.add("active");
            return false;
          }
          this.activateIconSidebarActive("#" + parentCollapseDiv.getAttribute("id"));
          return false;
        }
        return false;
      },
  
      toggleMenu() {
        document.body.classList.toggle("sidebar-enable");
  
        if (window.screen.width >= 992) {
          // eslint-disable-next-line no-unused-vars
          router.afterEach((routeTo, routeFrom) => {
            document.body.classList.remove("sidebar-enable");
            document.body.classList.remove("vertical-collpsed");
          });
          document.body.classList.toggle("vertical-collpsed");
        } else {
          // eslint-disable-next-line no-unused-vars
          router.afterEach((routeTo, routeFrom) => {
            document.body.classList.remove("sidebar-enable");
          });
          document.body.classList.remove("vertical-collpsed");
        }
        this.isMenuCondensed = !this.isMenuCondensed;
      },
  
      toggleRightSidebar() {
        document.body.classList.toggle("right-bar-enabled");
      },
  
      hideRightSidebar() {
        document.body.classList.remove("right-bar-enabled");
      },
    },
  
    mounted() {
      this.initActiveMenu();
      if (this.rmenu == "vertical" && this.layoutType == "twocolumn") {
        document.documentElement.setAttribute("data-layout", "vertical");
      }
      document.getElementById("overlay").addEventListener("click", () => {
        document.body.classList.remove("vertical-sidebar-enable");
      });
  
      window.addEventListener("resize", () => {
        if (this.layoutType == "twocolumn") {
          var windowSize = document.documentElement.clientWidth;
          if (windowSize < 767) {
            document.documentElement.setAttribute("data-layout", "vertical");
            this.rmenu = "vertical";
            localStorage.setItem("rmenu", "vertical");
          } else {
            document.documentElement.setAttribute("data-layout", "twocolumn");
            this.rmenu = "twocolumn";
            localStorage.setItem("rmenu", "twocolumn");
            setTimeout(() => {
              this.initActiveMenu();
            }, 50);
          }
        }
      });
    },
  };
  </script>
  
  <template>
    <div id="layout-wrapper">
      <NavBar />
      <div>
        <!-- ========== Left Sidebar Start ========== -->
        <!-- ========== App Menu ========== -->
        <div class="app-menu navbar-menu">
          <!-- LOGO -->
          <div class="navbar-brand-box">
            <!-- Dark Logo-->
            <router-link to="/" class="logo logo-dark">
              <span class="logo-sm">
                <img src="@/assets/images/common/alisan-logo.png" alt="" height="22" />
              </span>
              <span class="logo-lg">
                <img src="@/assets/images/common/alisan-logo-normal.png" alt="" height="40" />
              </span>
            </router-link>
            <!-- Light Logo-->
            <router-link to="/" class="logo logo-light">
              <span class="logo-sm">
                <img src="@/assets/images/common/alisan-logo.png" alt="" height="22" />
              </span>
              <span class="logo-lg">
                <img src="@/assets/images/common/alisan-logo-normal.png" alt="" height="40" />
              </span>
            </router-link>
            <button
              type="button"
              class="btn btn-sm p-0 fs-20 header-item float-end btn-vertical-sm-hover"
              id="vertical-hover"
            >
              <i class="ri-record-circle-line"></i>
            </button>
          </div>
  
          <div id="scrollbar" v-if="rmenu == 'twocolumn'">
            <div class="container-fluid">
              <div id="two-column-menu">
                <SimpleBar class="twocolumn-iconview list-unstyled">
                <a href="/" class="logo"
                  ><img src="@/assets/images/common/alisan-logo.png" alt="Logo" height="22"
                /></a>
                <li>
                  <a
                    :title="$t('t-dashboard')"
                    class="nav-icon"
                    href="#sidebarDashboards"
                    role="button"
                    @click.prevent="updateMenu('sidebarDashboards')"
                  >
                    <i class="ri-dashboard-2-line" :title="$t('t-dashboard')"></i>
                  </a>
                </li>
                <li>
                  <a
                    :title="$t('t-information-technologies-rd')"
                    class="nav-icon"
                    href="#sidebarInformationTechnologies"
                    role="button"
                    @click.prevent="updateMenu('sidebarInformationTechnologies')"
                  >
                    <i
                      class="ri-macbook-line"
                      :title="$t('t-information-technologies-rd')"
                    ></i>
                  </a>
                </li>
                <li>
                  <a
                    :title="$t('t-human-resources')"
                    class="nav-icon"
                    href="#sidebarHumanResources"
                    role="button"
                    @click.prevent="updateMenu('sidebarHumanResources')"
                  >
                    <i
                      class="ri-account-circle-line"
                      :title="$t('t-human-resources')"
                    ></i>
                  </a>
                </li>
                <li>
                  <a
                    :title="$t('t-management-systems-projects')"
                    class="nav-icon"
                    href="#sidebarManagement"
                    role="button"
                    @click.prevent="updateMenu('sidebarManagement')"
                  >
                    <i
                      class="ri-group-line"
                      :title="$t('t-management-systems-projects')"
                    ></i>
                  </a>
                </li>
                <li>
                  <a
                    :title="$t('t-administrative-affairs')"
                    class="nav-icon"
                    href="#sidebarAdministrativeAffairs"
                    role="button"
                    @click.prevent="updateMenu('sidebarAdministrativeAffairs')"
                  >
                    <i
                      class="ri-folder-4-line"
                      :title="$t('t-administrative-affairs')"
                    ></i>
                  </a>
                </li>

                <li>
                  <a
                    :title="$t('t-financial-affairs')"
                    class="nav-icon"
                    href="#sidebarAccounting"
                    role="button"
                    @click.prevent="updateMenu('sidebarAccounting')"
                  >
                    <i class="ri-funds-box-line" :title="$t('t-financial-affairs')"></i>
                  </a>
                </li>
                <li>
                  <a
                    :title="$t('t-buy-systems')"
                    class="nav-icon"
                    href="#sidebarPurchasing"
                    role="button"
                    @click.prevent="updateMenu('sidebarPurchasing')"
                  >
                    <i class="ri-shopping-cart-line" :title="$t('t-buy-systems')"></i>
                  </a>
                </li>
                <li>
                  <a
                    :title="$t('t-insurance')"
                    class="nav-icon"
                    href="#sidebarInsurance"
                    role="button"
                    @click.prevent="updateMenu('sidebarInsurance')"
                  >
                    <i class="ri-hand-coin-line" :title="$t('t-insurance')"></i>
                  </a>
                </li>
                <li>
                  <a
                    :title="$t('t-law')"
                    class="nav-icon"
                    href="#sidebarLaw"
                    role="button"
                    @click.prevent="updateMenu('sidebarLaw')"
                  >
                    <i class="ri-scales-line" :title="$t('t-law')"></i>
                  </a>
                </li>
              </SimpleBar>
              </div>
              <template v-if="layoutType === 'twocolumn'">
                <SimpleBar class="navbar-nav" id="navbar-nav">
                <li class="menu-title">
                  <span data-key="t-menu"> {{ $t("t-menu") }}</span>
                </li>
                <li class="nav-item">
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
                  <div class="collapse menu-dropdown" id="sidebarInformationTechnologies">
                    <h6
                      class="page-title mb-sm-2"
                      style="margin-left: 10px; font-weight: bold"
                    >
                      {{ $t("t-information-technologies-rd") }}
                    </h6>
                    <hr />
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
                        <div class="collapse menu-dropdown" id="sidebarServiceManagement">
                          <ul class="nav nav-sm flex-column">
                            <li class="nav-item">
                              <router-link
                              to="/btandrnd/information-technologies-rd/service-management/fault-management"
                                class="nt-buy-sysav-link custom-abc"
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

                                to="/btandrnd/information-technologies-rd/service-management/compatilibity"                                class="nav-link"
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
                                class="nav-link custom-abc"
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
                        <a
                          href="#sidebarInformationSecurity"
                          class="nav-link"
                          data-bs-toggle="collapse"
                          role="button"
                          aria-expanded="false"
                          aria-controls="sidebarInformationSecurity"
                          data-key="t-information-security"
                        >
                          {{ $t("t-information-security") }}
                        </a>
                        <div class="collapse menu-dropdown" id="sidebarInformationSecurity">
                          <ul class="nav nav-sm flex-column">
                  
                          </ul>
                        </div>
                      </li>
                    </ul>
                  </div>
                </li>
                <li class="nav-item">
                  <div class="collapse menu-dropdown" id="sidebarHumanResources">
                    <h6
                      class="page-title mb-sm-2"
                      style="margin-left: 10px; font-weight: bold"
                    >
                      {{ $t("t-human-resources") }}
                    </h6>
                    <hr />
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
                                class="nav-link custom-abc"
                                data-key="t-personnel-demand"
                              >
                                {{ $t("t-personnel-demand") }}
                              </router-link>
                            </li>
                            <li class="nav-item">
                              <router-link
                                to="/other/human-resources/personnel-management/selection-and-placement-form"
                                class="nav-link custom-abc"
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
                        <div class="collapse menu-dropdown" id="sidebarEducationProcess">
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
                        <div class="collapse menu-dropdown" id="sidebarPersonnelAffairs">
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
                          <ul class="nav nav-sm flex-column"></ul>
                        </div>
                      </li>
                    </ul>
                  </div>
                </li>
                <li class="nav-item">
                  <div class="collapse menu-dropdown" id="sidebarManagement">
                    <h6
                      class="page-title mb-sm-2"
                      style="margin-left: 10px; font-weight: bold"
                    >
                      {{ $t("t-management-systems-projects") }}
                    </h6>
                    <hr />
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
                        to="/other/management-systems-projects/internal-customer-complaint-process"
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
                <li class="nav-item">
                  <div class="collapse menu-dropdown" id="sidebarAdministrativeAffairs">
                    <h6
                      class="page-title mb-sm-2"
                      style="margin-left: 10px; font-weight: bold"
                    >
                      {{ $t("t-administrative-affairs") }}
                    </h6>
                    <hr />
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
                <li class="nav-item">
                  <div class="collapse menu-dropdown" id="sidebarAccounting">
                    <h6
                      class="page-title mb-sm-2"
                      style="margin-left: 10px; font-weight: bold"
                    >
                      {{ $t("t-financial-affairs") }}
                    </h6>
                    <hr />
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

                
                <li class="nav-item">
                  <div class="collapse menu-dropdown" id="sidebarPurchasing">
                    <h6
                      class="page-title mb-sm-2"
                      style="margin-left: 10px; font-weight: bold"
                    >
                      {{ $t("t-buy") }}
                    </h6>
                    <hr />
                    <ul class="nav nav-sm flex-column">
                      <li class="nav-item">
                        <a
                          href="#sidebarPurchasingSystem"
                          class="nav-link"
                          data-bs-toggle="collapse"
                          role="button"
                          aria-expanded="false"
                          aria-controls="sidebarPurchasingSystem"
                          data-key="t-purchasing-system"
                        >
                          {{ $t("t-purchasing-system") }}
                        </a>
                        <div class="collapse menu-dropdown" id="sidebarPurchasingSystem">
                          <ul class="nav nav-sm flex-column">
                            <li class="nav-item">
                              <router-link
                              to="/btandrnd/buy-systems/buy-process/buy-request"
                                class="nav-link"
                                data-key="t-fault-managementa"
                              >
                                {{ ("Satın Alma İsteği") }}
                              </router-link>
                            </li>
                            <li class="nav-item">
                              <router-link
                              to="/btandrnd/buy-systems/buy-process/buy-accept"
                                class="nav-link"
                                data-key="t-fault-management"
                              >
                                {{ ("Satın Alma Onay") }}
                              </router-link>
                            </li>
                          </ul>
                        </div>
                      </li>
                    </ul>
                  </div>
                </li>

                <li class="nav-item">
                  <div class="collapse menu-dropdown" id="sidebarInsurance">
                    <h6
                      class="page-title mb-sm-2"
                      style="margin-left: 10px; font-weight: bold"
                    >
                      {{ $t("t-insurance") }}
                    </h6>
                    <hr />
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

                <li class="nav-item">
                  <div class="collapse menu-dropdown" id="sidebarLaw">
                    <h6
                      class="page-title mb-sm-2"
                      style="margin-left: 10px; font-weight: bold"
                    >
                      {{ $t("t-law") }}
                    </h6>
                    <hr />
                    <ul class="nav nav-sm flex-column">
                      <li class="nav-item">
                        <a
                          href="#sidebarLawSystem"
                          class="nav-link"
                          data-bs-toggle="collapse"
                          role="button"
                          aria-expanded="false"
                          aria-controls="sidebarLawSystem"
                          data-key="t-law-system"
                        >
                          {{ $t("Dosyalar") }}
                        </a>
                        <div class="collapse menu-dropdown" id="sidebarLawSystem">
                          <ul class="nav nav-sm flex-column">
                            <li class="nav-item">
                              <router-link
                              to="/btandrnd/law-systems/law-process/law-accept"
                                class="nav-link"
                                data-key="t-law-management"
                              >
                                {{ ("Davalar") }}
                              </router-link>
                            </li>
                            <li class="nav-item">
                              <router-link
                              to="/btandrnd/law-systems/law-process/law-accept2"
                                class="nav-link"
                                data-key="t-law-management"
                              >
                                {{ ("Duruşma Saat Ekle") }}
                              </router-link>
                            </li>
                            <li class="nav-item">
                              <router-link
                              to="/btandrnd/law-systems/law-process/law-result"
                                class="nav-link"
                                data-key="t-law-management"
                              >
                                {{ ("Sonuçlanan Davalar") }}
                              </router-link>
                            </li>
                            <li class="nav-item">
                              <router-link
                              to="/btandrnd/law-systems/law-process/law-yonetici"
                                class="nav-link"
                                data-key="t-law-management"
                              >
                                {{ ("Dava Yönetimi") }}
                              </router-link>
                            </li>
                          </ul>
                        </div>
                      </li>
                    </ul>
                  </div>
                </li>
              </SimpleBar>
              </template>
            </div>
          </div>
  
          <SimpleBar
            id="scrollbar"
            class="h-100"
            ref="scrollbar"
            v-if="rmenu == 'vertical'"
          >
            <Menu></Menu>
          </SimpleBar>
        </div>
        <!-- Left Sidebar End -->
        <!-- Vertical Overlay-->
        <div class="vertical-overlay" id="overlay"></div>
      </div>
  
      <div class="main-content">
        <div class="page-content">
          <!-- Start Content-->
          <div class="container-fluid">
            <slot />
          </div>
        </div>
        <Footer />
      </div>
      <RightBar />
    </div>
  </template>
