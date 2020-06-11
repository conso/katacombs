package com.wallapop.katacombs

import com.wallapop.katacombs.application.CreatePlayerController
import com.wallapop.katacombs.application.Player
import com.wallapop.katacombs.application.PlayerRequest
import com.wallapop.katacombs.context.game.domain.create.PlayerCreator
import com.wallapop.katacombs.context.user.domain.UserId
import io.mockk.mockk
import io.mockk.verify
import org.junit.jupiter.api.Test
import java.util.UUID

class CreatePlayerControllerTest{
    val creator:PlayerCreator = mockk(relaxed = true)
    val createPlayerController = CreatePlayerController(creator)

    @Test
    fun `should create a player`(){
        val player = Player(UUID.randomUUID().toString(), "Gerard")

        createPlayerController.createPlayer(PlayerRequest(player))

        verify {
            creator(UserId.fromString(player.sid))
        }
    }

}

