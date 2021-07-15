PLUGIN.Title = "Welcome Message"
PLUGIN.Author = "Bob"
PLUGIN.Version = V(0, 1, 0)
PLUGIN.Description = "Welcome Message"

spawn = {}

function PLUGIN:Init()
    --command.AddChatCommand("q", self.Plugin, "q")
end

function PLUGIN:OnPlayerInit(player)
    rust.BroadcastChat(player.displayName.." зашел на сервер.")
    spawn[player] = true
end

function PLUGIN:OnPlayerDisconnected(player, reason)
    rust.BroadcastChat(player.displayName.." вышел с сервера.")
    if spawn[player] then spawn[player] = nil end
end

function PLUGIN:OnPlayerSleepEnded(player)
    if spawn[player] then
        spawn[player] = nil
        rust.SendChatMessage(player, "Добро пожаловать на сервер IGM! Приятной игры!")
        rust.SendChatMessage(player, "Наш сайт - igmserver.ru.")
        rust.SendChatMessage(player, "Наша группа ВКонтакте - vk.com/rustfans.")
    end
end