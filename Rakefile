desc 'Start ravendb'
task 'start-raven' do
	exec %{src/packages/RavenDB.1.0.658-Unstable/server/Raven.Server.exe}
end

desc 'Start web server'
task 'start-server' do
	cmd = ".\\tools\\IISExpress\\iisexpress.exe /path:#{File.dirname(__FILE__).gsub("/","\\")}\\src\\Ogum.UI /port:3000"
	exec cmd
end