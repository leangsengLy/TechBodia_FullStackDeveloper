<template>
  <div class="w-screen h-screen flex justify-center items-center">
    <div class="grid gap-y-3 w-[320px] px-4" >
        <div class="flex justify-center flex-col items-center">
          <p class="text-[24px] font-bold ">{{ isSignup?'Create your account':'Enter your password' }}</p>
          <div v-if="isSignup" class="flex justify-center text-center items-center text-[12px] mt-2">
              <p>Note that phone verification may be required for signup. Your number will only be used to verify your identity for security purpose.</p>
          </div>
        </div>
        <div class="flex flex-col gap-y-3"> 
          <v-text-field clearable  @input="OnChange('email')"  @keydown="handleKeydown" autofocus ref="myInput" :rules="[rules.requiredEmail, rules.email]"  persistent-clear label="Email"  v-model="email" variant="outlined"></v-text-field>
          <v-text-field clearable :type="typeInput"  @input="OnChange('pw')"  persistent-clear  @keydown="handleKeydown" label="Password" :rules="[rules.requiredPw] " v-model="password" variant="outlined"></v-text-field>
          <v-text-field clearable :type="typeInput" @input="OnChange('pw')"  v-if="isSignup"  @keydown="handleKeydown" persistent-clear :rules="[rules.requiredPw] " label="Confirm Password"  v-model="confirmPassword" variant="outlined"></v-text-field>
          <p class="text-[13px] text-[#019250]" v-if="!isSignup">Forget password?</p>
        </div>
        <div class="flex justify-center hover:opacity-80 bg-[#019250] text-white py-4 text-[16px] cursor-pointer rounded-lg items-center" @click="onClickContinues">
          <span class="loading" v-if="isLoading"></span>
          Continues
        </div>
        <div class="flex justify-center flex-wrap items-center text-[13px]"><span>{{ isSignup?"Already have account?":"Don't have account?" }}</span> <span class="ml-2 text-[#019250] cursor-pointer" @click="onClickSignUp">{{isSignup?"Login":"Sign up"}}</span></div>
    </div>
      <v-snackbar
            :color="color"
            v-model="isShowSnackbar"
        >
            {{ msg }}
        </v-snackbar>
  </div>
</template>
<script setup lang="ts">
  import { ref, watch } from 'vue'
import { useLoginStore } from '../../store/login';
import { useRouter } from 'vue-router';
  const isSignup = ref<boolean>(false)
  const isLoading = ref<boolean>(false)
  const email = ref<string>("");
  const confirmPassword = ref<string>("");
  const typeInput = ref<string>("password");
  const msg = ref<string>("");  
  const password = ref<string>("");
  const router = useRouter()
  const color = ref<string>("error");
  const isFirstInputEmail = ref<boolean>(false);
  const isFirstInputPw = ref<boolean>(false);
  const isShowSnackbar = ref<boolean>(false);
  const login = useLoginStore();  
  const rules = ref({
  requiredEmail: (value: string) => {
    if(value=='' && (isFirstInputEmail.value)) return 'Email is required!';
    return true;
  },
  requiredPw: (value: string) => {
    if(value=='' && isFirstInputPw.value) return 'Password is required!';
    return true;
  },
  email: (value: string) =>{
    if(!(/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value)) && isFirstInputEmail.value) return 'Invalid email format!';
    return true;
  }
    // !value && isFirstInputPw.value|| /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value)   || '',
})
const handleKeydown = async (event:KeyboardEvent)=>{
    if(event.key === "Enter") confirmDataToCreate();

}
  const onClickSignUp=()=>{
    isSignup.value = !isSignup.value;
  }
  watch(isSignup,()=>{
    email.value = "";
    password.value = "";
    confirmPassword.value = "";
  })
  const OnChange=(type:string)=>{
    if(type=="pw") isFirstInputPw.value=true;
    else isFirstInputEmail.value=true;
  }
  const confirmDataToCreate= async()=>{
    if(password.value.trim()=="" || email.value.trim()==""){
      msg.value="Please check email or password is required.";
       color.value="error";
      isShowSnackbar.value  = true;
    }else {
      if(isSignup.value){
        if(password.value==confirmPassword.value) {
           isLoading.value  = true;
          const result = await login.CreateSignUp(email.value,password.value);
          console.log("check ",result?.data?.apiResponse?.detail)
          color.value  = result?.data?.apiResponse?.detail!="" && result?.data?.apiResponse?.detail!=undefined? "error":"success";
          msg.value  = result?.data?.apiResponse?.detail!="" && result?.data?.apiResponse?.detail!=undefined? result?.data?.apiResponse?.detail:"Create account successfully.";
          isShowSnackbar.value = true;
          isLoading.value  = false;
          if(!(result?.data?.apiResponse?.detail!="" && result?.data?.apiResponse?.detail!=undefined)){
            setTimeout(() => {
              password.value = "";
              email.value = "";
              confirmPassword.value = "";
              isSignup.value = false;
          }, 3000);
          }
          }
        else  {
            msg.value="Your password is difference with confirm password!"
            color.value="error";
            isShowSnackbar.value  = true;
        }
        
      }else{
        isLoading.value  = true;
         const result = await login.CreateSignUp(email.value,password.value,true);
         console.log("is success",result  )
         color.value  = !result ? "error":"success";
         msg.value  = result ? "login successfully.":"Your password is incorrect!";
         isShowSnackbar.value = true;
         isLoading.value  = false;
        setTimeout(()=>{
           if(result) router.push('/note')
        },1000)
      }
    }
    
  }
  const onClickContinues=()=>{
    confirmDataToCreate();
  }
</script>



<style lang="scss" scoped>

</style>