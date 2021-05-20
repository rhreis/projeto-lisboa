<template>
  <div id="app">
    <h1>Projeto Lisboa</h1>
    <Menu />
    <router-view />
  </div>
</template>

<script>
import Menu from './components/template/Menu'

export default {
  name: 'app',

  components: {
    Menu
  },

  data: () => ({
    //
  }),
};
</script>

<style>
	#app {
		display: flex;
		flex-direction:column;
		align-items: center;
	}
</style>