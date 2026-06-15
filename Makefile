DMG_OUTPUT_DIR = ./abl_dist/Install_Amazeing_Ball_1.0.dmg
DMG_INPUT_DIR  = ./abl_dist/Amazeing Ball.app
dmg:
	clear
	create-dmg \
    --volname "Install Amazeing Ball 1.0" \
    --volicon "Repo_Assets/mac_dmg/install_mac.icns" \
    --background "Repo_Assets/mac_dmg/dmgbg.png" \
    --window-pos 200 120 \
    --window-size 540 380 \
    --icon-size 80 \
    --icon "Amazeing Ball.app" 150 250 \
    --hide-extension "Amazeing Ball.app" \
    --app-drop-link 380 250 \
    "$(DMG_OUTPUT_DIR)" \
    "$(DMG_INPUT_DIR)"

	open $(DMG_OUTPUT_DIR)/..

	@echo [ INFO ] MACOS INSTALLER CREATED. Output located at $(DMG_OUTPUT_DIR)

