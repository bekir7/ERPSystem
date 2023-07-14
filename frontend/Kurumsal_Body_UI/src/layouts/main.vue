<script>
    import { layoutComputed } from "@/state/helpers";
    
    
    import TwoColumns from "./twocolumn";
    
    export default {
        components: {
           
            TwoColumns
        },
        data() {
            return {};
        },
        computed: {
            ...layoutComputed,
        },
    
    };
    </script>
    
    <template>
    <div>
      
    
        <TwoColumns v-if="layoutType === 'twocolumn'" :layout="layoutType">
            <slot />
        </TwoColumns>
    </div>
    </template>
    
