
export default [
  {
    path: "/",
    name: "default",
    meta: {
      title: "Dashboard",
      authRequired: true,
    },
    component: () => import("../views/dashboard/index.vue"),
  },
 {
    path: "/btandrnd/information-technologies-rd/service-management/fault-management",
    name: "fault-management",
    meta: {
      title: "Fault Management",
      authRequired: true,
    },
    component: () => import("../views/btandrnd/information-technologies-rd/service-management/fault-management/fault-management.vue"),
  },
  {
    path: "/btandrnd/information-technologies-rd/service-management/data-base",
    name: "data-base",
    meta: {
      title: "Data Base",
      authRequired: true,
    },
    component: () => import("../views/btandrnd/information-technologies-rd/service-management/data-base/data-base.vue"),
  },
  {
    path: "/btandrnd/information-technologies-rd/service-management/risk-management",
    name: "risk-management",
    meta: {
      title: "Risk Management",
      authRequired: true,
    },
    component: () => import("../views/btandrnd/information-technologies-rd/service-management/risk-management/risk-management.vue"),
  },
  {
    path: "/btandrnd/information-technologies-rd/service-management/compatilibity",
    name: "compatilibity",
    meta: {
      title: "Compatilibity",
      authRequired: true,
    },
    component: () => import("../views/btandrnd/information-technologies-rd/service-management/compatilibity/compatilibity.vue"),
  },
  {
    path: "/btandrnd/information-technologies-rd/service-management/inventory-management",
    name: "inventory-management",
    meta: {
      title: "Inventory Management",
      authRequired: true,
    },
    component: () => import("../views/btandrnd/information-technologies-rd/service-management/inventory-management/inventory-management.vue"),
  },
  {
    path: "/btandrnd/information-technologies-rd/service-management/admin-panel",
    name: "admin-panel",
    meta: {
      title: "Admin Panel",
      authRequired: true,
    },
    component: () => import("../views/btandrnd/information-technologies-rd/service-management/admin-panel/admin-panel.vue"),
  },
  {
    path: "/btandrnd/information-technologies-rd/project-management",
    name: "project-management",
    meta: {
      title: "Project Management",
      authRequired: true,
    },
    component: () => import("../views/btandrnd/information-technologies-rd/project-management/project-management.vue"),
  },
  {
    path: "/btandrnd/information-technologies-rd/kvkk-processes/change-management",
    name: "change-management",
    meta: {
      title: "Change Management",
      authRequired: true,
    },
    component: () => import("../views/btandrnd/information-technologies-rd/kvkk-processes/change-management/change-management.vue"),
  },
  {
    path: "/btandrnd/information-technologies-rd/kvkk-processes/it-system-access-process",
    name: "it-system-access-process",
    meta: {
      title: "IT System Access Process",
      authRequired: true,
    },
    component: () => import("../views/btandrnd/information-technologies-rd/kvkk-processes/it-system-access-process/it-system-access-process.vue"),
  },
  {
    path: "/btandrnd/buy-systems/buy-process/buy-request",
    name: "buy-request",
    meta: {
      title: "Buy Request",
      authRequired: true,
    },
    component: () => import("../views/btandrnd/buy-systems/buy-process/buy-request/buy-request.vue"),
  },
  {
    path: "/btandrnd/law-systems/law-process/law-accept",
    name: "law-accept",
    meta: {
      title: "Law Accept",
      authRequired: true,
    },
    component: () => import("../views/btandrnd/law-systems/law-process/law-accept/law-accept.vue"),
  },
  {
    path: "/btandrnd/law-systems/law-process/law-accept2",
    name: "law-accept2",
    meta: {
      title: "Law Accept2",
      authRequired: true,
    },
    component: () => import("../views/btandrnd/law-systems/law-process/law-accept2/law-accept2.vue"),
  },
  {
    path: "/btandrnd/law-systems/law-process/law-result",
    name: "law-result",
    meta: {
      title: "Law Result",
      authRequired: true,
    },
    component: () => import("../views/btandrnd/law-systems/law-process/law-result/law-result.vue"),
  },
  {
    path: "/btandrnd/law-systems/law-process/law-yonetici",
    name: "law-yonetici",
    meta: {
      title: "Law Yonetici",
      authRequired: true,
    },
    component: () => import("../views/btandrnd/law-systems/law-process/law-yonetici/law-yonetici.vue"),
  },
];