# @reference ../lib/backbone.js
# @reference models/task.coffee
# @reference collections/tasks.coffee
# @reference views/undoView.coffee
# @reference views/newTaskView.coffee
# @reference views/completedTaskView.coffee
# @reference views/taskView.coffee
# @reference views/tasksView.coffee
# @reference views/appView.coffee
# @reference routers/ogumRouter.coffee

@app = window.app ? {}

jQuery ->
  app.router = new app.OgumRouter()
  Backbone.history.start({pushState:true})
  #appView = new app.AppView collection: app.Tasks
  #app.Tasks.fetch()