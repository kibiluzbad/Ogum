desc 'Start ravendb'
task 'start-raven' do
	exec %{src/packages/RavenDB.1.0.616/server/Raven.Server.exe}
end

desc 'Start web server'
task 'start-server' do
	puts File.dirname(__FILE__)
	exec %{.\\tools\\IISExpress\\iisexpress.exe /path:D:\\Users\\Leonardo\\Work\\ogum\\src\\Ogum.UI /port:3000}
end