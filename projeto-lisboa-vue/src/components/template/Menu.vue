<template>
  <v-container fluid>
    <v-tabs>
      <v-tab>
        <router-link to="/" active-class="active" exact>
          List
        </router-link>
      </v-tab>
      <v-tab>
        <router-link to="/upload" active-class="active">
          Upload
        </router-link>
      </v-tab>
    </v-tabs>
  </v-container>
</template>

<script>
export default {

}
</script>

<style>

</style>
