fx_version 'bodacious'
game 'gta5'

files {
    'Client/*.dll',
    'static/card_background.jpg',
    'static/index.css',
    'static/index.js',
    'static/index.html'
}

client_script 'Client/*.net.dll'
server_script 'Server/*.net.dll'

author 'zabbix-byte'
version '1.0.0'
description 'ztzbx auth interface'

dependencies {
    "core-ztzbx",
    "language"
}

ui_pages {
    'static/index.html'
}