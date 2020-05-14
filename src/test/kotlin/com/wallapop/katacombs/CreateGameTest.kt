package com.wallapop.katacombs

import io.mockk.mockk
import io.mockk.verify
import org.junit.jupiter.api.Test
import java.util.UUID

class CreateGameTest {

    @Test
    fun `it should start game`() {
        val repository: GameRepository = mockk(relaxed = true)
        val userId = UserId(UUID.randomUUID())
        val expectedGame = Game(userId)

        val gameCreator = GameCreator(repository)
        gameCreator(userId)

        verify {
            repository.save(expectedGame)
        }

    }

}

class GameCreator(private val repository: GameRepository) {

    operator fun invoke(userId: UserId) {
        repository.save(Game(userId))
    }

}

data class Game(val userId: UserId)

data class UserId(val id: UUID)

interface GameRepository {

    fun save(game: Game)

}
