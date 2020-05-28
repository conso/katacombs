package com.wallapop.katacombs

import com.wallapop.katacombs.context.game.domain.Game
import com.wallapop.katacombs.context.game.domain.GameRepository
import com.wallapop.katacombs.context.game.domain.create.PlayerCreator
import com.wallapop.katacombs.context.user.domain.UserId
import io.mockk.mockk
import io.mockk.verify
import org.junit.jupiter.api.Test
import java.util.UUID

class CreatePlayerTest {

    @Test
    fun `it should start game`() {
        val repository: GameRepository = mockk(relaxed = true)
        val userId = UserId(UUID.randomUUID())
        val expectedGame = Game(userId)

        val gameCreator = PlayerCreator(repository)
        gameCreator.invoke(userId)

        verify {
            repository.save(expectedGame)
        }

    }

}

