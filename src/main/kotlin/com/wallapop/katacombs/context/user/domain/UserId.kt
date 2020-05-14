package com.wallapop.katacombs.context.user.domain

import java.util.UUID

data class UserId(val id: UUID) {
    companion object {
        fun fromString(id: String) = UserId(UUID.fromString(id))
    }
}
